#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <string.h>
#include <mysql/mysql.h>
#include <pthread.h>

typedef struct {
	char usuario[20];
	int socket;
}Conectado;

typedef struct {
	Conectado conectados[100];
	int num;
}ListaConectados;

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
ListaConectados miLista;

int PonConectado (ListaConectados *lista, char usuario[20], int socket) {
	//Devuelve -1 si la lista esta llena
	//Devuelve 0 si ha podido a�adir el usuario a la lista
	if (lista->num == 100)
		return -1;
	else {
		strcpy (lista -> conectados [lista -> num].usuario, usuario);
		lista -> conectados[lista -> num].socket = socket;
		lista -> num++;
		return 0;
	}
}

int DamePosicion (ListaConectados *lista, char usuario[20]){
	//Devuelve la posicion o -1 si no esta en la lista
	int i = 0;
	int encontrado = 0;
	while ((i < lista -> num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].usuario,usuario) == 0)
			encontrado = 1;
		if (!encontrado)
			pthread_mutex_lock(&mutex);
			i = i+1;	
			pthread_mutex_unlock(&mutex);
	}
	if (encontrado)
		return i;
	else
		return -1;
}

int Eliminar (ListaConectados *lista, char usuario[20]){
	//Devuelve 0 si elimina al usuario de la lista
	//Devuelve -1 si no ha podido eliminar al usuario de la lista
	int pos = DamePosicion (lista, usuario);
	if (pos == -1)
		return -1;
	else{
		int i;
		for (i = pos; i < lista->num-1; i++)
		{
			lista -> conectados[i] = lista -> conectados[i+1];
			//strcpy(lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			//lista->conectados[i].socket = lista->conectados[i+1].socket;
		}
		lista->num--;
		return 0;
	}		
}

void DameConectados (ListaConectados *lista, char conectados [300]){
	//Pone en conectados los nombres de todos los conectados separados por /
	sprintf(conectados, "%d", lista->num);
	int i;
	for (i=0; i< lista->num; i++)
		sprintf(conectados, "%s/%s", conectados, lista->conectados[i].usuario);
}

void *AtenderCliente (void *socket)
{ 
	int sock_conn;
	int ret;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	char peticion[512];
	char respuesta[512];
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
	
		
		int terminar = 0;
		while (!terminar)
		{
			ret = read(sock_conn, peticion, sizeof(peticion));
			printf("Recibido\n");
			peticion[ret] = '\0';
			printf("Peticion: %s\n", peticion);
			
			char username[20];
			char password[40];
			char nombre[40];
			int edad;
			int id_jugador;
			char *p = strtok(peticion, "/");
			int codigo = atoi(p);
			if (p == NULL) {
				printf("Error: No se recibio un codigo valido.\n");
				return 0;
			}
			if ((codigo<3)&&(codigo != 0))
			{
				
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(username, p);
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(password, p);
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(nombre, p);
				p = strtok(NULL, "/");
				if (p != NULL) 
					edad = atoi(p);  
				
				printf("Codigo: %d, username: %s, password_p: %s, nombre: %s, edad: %d\n", codigo, username, password, nombre, edad);
			}
			
			if (codigo == 0) {
				Eliminar(&miLista, username);
				printf("Usuario desconectado: %s\n", username);
				break;
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
					sprintf(respuesta,"El usuario y/o la contrase�a�no son correctos\n");
				} else {
					sprintf(respuesta,"Se ha iniciado sesion correctamente, bienvenido %s\n", row[0]);
				}
				printf("%s", respuesta);
				send(sock_conn, respuesta, strlen(respuesta), 0);
				PonConectado(&miLista, username, sock_conn);
				printf("Usuario conectado: %s\n", username);
				//Registar
			} else if (codigo == 2) {
				sprintf(insertar, "INSERT INTO jugadores ( username, password_p, nombre, edad, id_partida) VALUES ('%s', '%s', '%s', %d, NULL);", 
						username, password, nombre, edad);		
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
			} //Consulta el historial 
			else if(codigo==3){
				char id_jugador[20];
				char *c = strtok(NULL, "/");
				strcpy(id_jugador,c);
				printf("ID del jugador extraído: %s\n", id_jugador);  // Verifica el ID extraído
				printf("Dame el ID del usuario que quieres consultar su historial\n");
				sprintf (consulta,"SELECT * FROM historial WHERE id_jugador = '%s'", id_jugador);
				printf("Consulta generada: %s\n", consulta); 
				err = mysql_query(conn, consulta);
				if (err != 0) {
					printf( "Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				
				if (row == NULL) {
					sprintf(respuesta, "No se han obtenido datos\n");
				} else {
					sprintf(respuesta, "Partidas jugadas: %s, Partidas ganadas: %s, Beneficio total: %s, id_jugador: %s", row[0], row[1], row[2],row[3]);
				}
				printf("%s", respuesta);
				send(sock_conn, respuesta, strlen(respuesta), 0);
			}//Consulta la duracion de partida 
			else if (codigo == 4) {
				char id_partida[80];
				char *c = strtok(NULL, "/");
				strcpy (id_partida,c);
				printf("ID de partida recibido: %s\n", id_partida);
				
				//printf("Dime el id de la partidas que quieres buscar: ");
				sprintf(consulta, "SELECT duracion FROM partidas WHERE id_partida = '%d'", atoi (id_partida));
				printf("Consulta ejecutada: [%s]\n", consulta);
				err = mysql_query(conn, consulta);
				printf("Resultado de mysql_query: %d\n", err);				
				if (err != 0) {
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
				int num_rows = mysql_num_rows(resultado);
				printf("Numero de filas obtenidas: %d\n", num_rows);
				
				if (num_rows > 0) {
					row = mysql_fetch_row(resultado);
					if (row) {
						printf("Duracion de la partida obtenida: %s\n", row[0]);
						sprintf(respuesta, "Duracion de la partida: %s\n", row[0]);
					} else {
						printf("Error al obtener la fila.\n");
					}
				}
				printf("%s", respuesta);
				send(sock_conn, respuesta, strlen(respuesta), 0);
			}//Consulta limite de edad
			else if (codigo == 5) {
				char id_partida[80];
				char *c = strtok(NULL, "/");
				strcpy (id_partida,c);
				printf("ID de partida recibido: %s\n", id_partida);
				sprintf(consulta, "SELECT limite_edad FROM partidas WHERE id_partida = '%d'", atoi (id_partida));
				err = mysql_query(conn, consulta);
				if (err != 0) {
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
				int num_rows = mysql_num_rows(resultado);
				printf("Numero de filas obtenidas: %d\n", num_rows);
				
				if (num_rows > 0) {
					row = mysql_fetch_row(resultado);
					if (row) {
						printf("Limite de edad: %s\n", row[0]);
						sprintf(respuesta, "Limite de edad: %s\n", row[0]);
					} else {
						printf("Error al obtener la fila.\n");
					}
				}
				printf("%s", respuesta);
				send(sock_conn, respuesta, strlen(respuesta), 0);
			}
			else if (codigo == 6) {  // Cliente pide la lista de usuarios conectados
				char conectados[300];
				DameConectados(&miLista, conectados);
				send(sock_conn, conectados, strlen(conectados), 0);
			}
		}
		close(sock_conn);
}
int main(int argc, char *argv[])
{
	miLista.num = 0;
	
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
		printf("Error al crear socket\n");
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
	
	pthread_t thread[100];
	int sockets[100];
	int i = 0;
	
	while (1) {
		printf("Escuchando...\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("He recibido conexion\n");
		
		sockets[i] = sock_conn;
		pthread_create(&thread[i], NULL, AtenderCliente, &sockets[i]);
		i++;
	}
	return 0;
}



