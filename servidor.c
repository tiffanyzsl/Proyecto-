#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <string.h>
#include <mysql/mysql.h>

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
		printf("Error al crear socket\n");
		exit(1);
	}
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la m?quina.
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9080
	serv_adr.sin_port = htons(9080);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0) {
		printf("Error en el bind\n");
		exit(1);
	}
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 3) < 0) {
		printf("Error en el listen\n");
		exit(1);
	}
	
	// Conexiï¿ƒï¾³n a la base de datos MySQL
	MYSQL *conn;
	int err;
	char consulta[256];
	char insertar[256];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error al crear conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect(conn, "localhost", "root", "mysql", "carrera_caballos", 0 , NULL, 0);
	if (conn == NULL) {
		printf("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	err = mysql_query(conn, "USE carrera_caballos;");
	if (err != 0) {
		printf("Error al seleccionar la base de datos: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	// Atenderemos solo 10 peticione
	for(;;){
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		int terminar = 0;
		while (terminar == 0)
		{
			ret = read(sock_conn, peticion, sizeof(peticion));
			printf("Recibido\n");
			peticion[ret] = '\0';
			printf("Peticion: %s\n", peticion);
			
			char nombre[40];
			char username[20];
			char password[40];
			int edad;
			char *p = strtok(peticion, "/");
			int codigo = atoi(p);
			if (p == NULL) {
				printf("Error: No se recibio un codigo valido.\n");
				return 0;
			}
			if ((codigo<3)&&(codigo != 0))
			{
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(nombre, p);
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(username, p);
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(password, p);
				p = strtok(NULL, "/");
				if (p != NULL) 
				edad = atoi(p);  
				printf("Codigo: %d, nombre: %s, username: %s, password_p: %s, edad: %d\n", codigo, nombre, username, password, edad);
			}
			
			if (codigo == 0) {
				terminar = 1;
				//INICIAR SESION
			} else if (codigo == 1) {
				sprintf(consulta, "SELECT username, password_p FROM jugadores WHERE username =  '%s' AND password_p =  '%s'",username,password);
				printf("Consulta SQL: %s\n", consulta);
				err = mysql_query(conn, consulta);
				if (err != 0) {
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				if (resultado == NULL) {
					printf("Error al obtener el resultado: %s\n", mysql_error(conn));
					exit(1);
				} else {
					int num_rows = mysql_num_rows(resultado);
					printf("Numero de filas devueltas: %d\n", num_rows);
				}
				
				if (row == NULL) {
					sprintf(respuesta,"El usuario y/o la contraseña no son correctos\n");
				} else {
					sprintf(respuesta,"Se ha iniciado sesion correctamente, bienvenido %s\n", row[0]);
				}
				printf("%s", respuesta);
				send(sock_conn, respuesta, strlen(respuesta), 0);
				//Registar
			} else if (codigo == 2) {
				sprintf(insertar, "INSERT INTO jugadores (nombre, username, password_p, edad, id_partida) VALUES ('%s', '%s', '%s', %d, NULL);", 
						nombre, username, password, edad);		
				printf("Consulta SQL para insertar: %s\n", insertar);
				err = mysql_query(conn, insertar);
				if (err != 0) {
					printf("Error MySQL: %u - %s\n", mysql_errno(conn), mysql_error(conn));
					sprintf(respuesta, "Error al insertar datos en la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				else{
					if (mysql_affected_rows(conn) > 0) {
						sprintf(respuesta, "Usuario registrado correctamente: %s\n", username);
					} else {
						sprintf(respuesta, "No se pudo registrar el usuario.\n");
					}
				}
				send(sock_conn, respuesta, strlen(respuesta), 0);
			}
		}
		close(sock_conn);
	}
	mysql_close(conn);
	return 0;
}
