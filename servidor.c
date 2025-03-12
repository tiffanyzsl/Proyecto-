#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <mysql/mysql.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <unistd.h>

#define PUERTO 8080
#define MAX_CLIENTES 5
#define BUFFER_SIZE 1024

// Funcion para conectar con MySQL
MYSQL* conectar_bd() {
	MYSQL *conn = mysql_init(NULL);
	if (conn == NULL) {
		fprintf(stderr, "Error al inicializar MySQL: %s\n", mysql_error(conn));
		exit(1);
	}
	if (!mysql_real_connect(conn, "localhost", "root", "mysql", "carrera_caballos", 0, NULL, 0)) {
		fprintf(stderr, "Error de conexion: %s\n", mysql_error(conn));
		exit(1);
	}
	return conn;
}

// Funcion para registrar un jugador
void registrar_jugador(MYSQL *conn, char *nombre, int edad) {
	char consulta[BUFFER_SIZE];
	sprintf(consulta, "INSERT INTO jugadores (nombre, edad) VALUES ('%s', %d)", nombre, edad);
	
	if (mysql_query(conn, consulta)) {
		fprintf(stderr, "Error al registrar jugador: %s\n", mysql_error(conn));
	} else {
		printf("Jugador registrado correctamente.\n");
	}
}

// Funcion para obtener la duracion de una partida
void obtener_duracion_partida(MYSQL *conn, int id_partida, char *resultado) {
	char consulta[BUFFER_SIZE];
	sprintf(consulta, "SELECT duracion FROM partidas WHERE id_partida = %d", id_partida);
	
	if (mysql_query(conn, consulta)) {
		sprintf(resultado, "Error en la consulta: %s\n", mysql_error(conn));
		return;
	}
	
	MYSQL_RES *res = mysql_store_result(conn);
	MYSQL_ROW row = mysql_fetch_row(res);
	if (row) {
		sprintf(resultado, "Duracion de la partida %d: %s minutos\n", id_partida, row[0]);
	} else {
		sprintf(resultado, "No se encontro la partida %d\n", id_partida);
	}
	mysql_free_result(res);
}

// Funcion para obtener el historial de partidas
void obtener_historial_partidas(MYSQL *conn, char *resultado) {
	char consulta[BUFFER_SIZE] = "SELECT * FROM partidas";
	
	if (mysql_query(conn, consulta)) {
		sprintf(resultado, "Error en la consulta: %s\n", mysql_error(conn));
		return;
	}
	
	MYSQL_RES *res = mysql_store_result(conn);
	MYSQL_ROW row;
	strcpy(resultado, "Historial de partidas:\n");
	
	while ((row = mysql_fetch_row(res))) {
		char fila[BUFFER_SIZE];
		sprintf(fila, "ID: %s | Fecha: %s | LÃ­mite de edad: %s\n", row[0], row[1], row[2]);
		strcat(resultado, fila);
	}
	mysql_free_result(res);
}
// Funcion para obtener el li­mite de edad de una partida
void obtener_limite_edad(MYSQL *conn, int id_partida, char *resultado) {
	char consulta[BUFFER_SIZE];
	sprintf(consulta, "SELECT limite_edad FROM partidas WHERE id_partida = %d", id_partida);
	
	if (mysql_query(conn, consulta)) {
		sprintf(resultado, "Error en la consulta: %s\n", mysql_error(conn));
		return;
	}
	MYSQL_RES *res = mysql_store_result(conn);
	MYSQL_ROW row = mysql_fetch_row(res);
	if (row) {
		sprintf(resultado, "Li­mite de edad para la partida %d: %s años\n", id_partida, row[0]);
	} else {
		sprintf(resultado, "No se encontro la partida %d\n", id_partida);
	}
	mysql_free_result(res);
}

// Funcion para manejar clientes
void manejar_cliente(int cliente_socket) {
	MYSQL *conn = conectar_bd();
	char buffer[BUFFER_SIZE];
	
	while (1) {
		memset(buffer, 0, BUFFER_SIZE);
		int leido = recv(cliente_socket, buffer, BUFFER_SIZE, 0);
		if (leido <= 0) break;
		
		printf("Mensaje recibido: %s\n", buffer);
		char respuesta[BUFFER_SIZE];
		
		if (strncmp(buffer, "REGISTRAR", 9) == 0) {
			char nombre[50];
			int edad;
			sscanf(buffer, "REGISTRAR %s %d", nombre, &edad);
			registrar_jugador(conn, nombre, edad);
			strcpy(respuesta, "Registro exitoso.\n");
		
		} else if (strncmp(buffer, "DURACION", 8) == 0) {
			int id_partida;
			sscanf(buffer, "DURACION %d", &id_partida);
			obtener_duracion_partida(conn, id_partida, respuesta);
			
		} else if (strncmp(buffer, "HISTORIAL", 9) == 0) {
			obtener_historial_partidas(conn, respuesta);
			
		} else if (strncmp(buffer, "LIMITE_EDAD", 6) == 0) {
			int id_partida;
			sscanf(buffer, "LIMITE %d", &id_partida);
			obtener_limite_edad(conn, id_partida, respuesta);
			
		} else {
			strcpy(respuesta, "Comando no reconocido.\n");
		}
		
		send(cliente_socket, respuesta, strlen(respuesta), 0);
	}	
	close(cliente_socket);
	mysql_close(conn);
}
int main() {
	int servidor_socket, cliente_socket;
	struct sockaddr_in servidor_addr, cliente_addr;
	socklen_t cliente_len = sizeof(cliente_addr);
	
	servidor_socket = socket(AF_INET, SOCK_STREAM, 0);
	servidor_addr.sin_family = AF_INET;
	servidor_addr.sin_addr.s_addr = INADDR_ANY;
	servidor_addr.sin_port = htons(PUERTO);
	bind(servidor_socket, (struct sockaddr*)&servidor_addr, sizeof(servidor_addr));
	listen(servidor_socket, MAX_CLIENTES);
	printf("Servidor escuchando en el puerto %d...\n", PUERTO);
	
	while (1) {
		cliente_socket = accept(servidor_socket, (struct sockaddr*)&cliente_addr, &cliente_len);
		if (cliente_socket >= 0) {
			printf("Cliente conectado.\n");
			manejar_cliente(cliente_socket);
		}
	}
	
	close(servidor_socket);
	return 0;
}