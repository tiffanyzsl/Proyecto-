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
	int id_partida;
<<<<<<< HEAD
	int estado; // 0 si esta desconectado y 1 si esta conectado
	char resultado_partida[20]; // WIN o LOSE
	float beneficio_partida;
=======
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
}Conectado;

typedef struct {
	Conectado conectados[100];
	int num;
}ListaConectados;

int i;
int sockets[100];
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
ListaConectados miLista;

<<<<<<< HEAD
int PonConectado(ListaConectados *lista, char usuario[20], int socket, int id_partida) {
    // Devuelve -1 si la lista está llena
    // Devuelve 0 si ha podido añadir el usuario a la lista
    if (lista->num == 100)
        return -1;
    else {
        strcpy(lista->conectados[lista->num].usuario, usuario);
        lista->conectados[lista->num].socket = socket;
		lista->conectados[lista->num].estado = 1;      // Marcamos como conectado
		lista->conectados[lista->num].id_partida = id_partida;
        lista->num++;
        return 0;
    }
}

=======
void DameConectados (ListaConectados *lista, char conectados [300]){
	//Pone en conectados los nombres de todos los conectados separados por /
	sprintf(conectados, "6/%d", lista->num);
	for (int i = 0; i < lista->num; i++) {
        strcat(conectados, "/");
        strcat(conectados, lista->conectados[i].usuario);
    }
}

int PonConectado(ListaConectados *lista, char usuario[20], int socket) {
    // Devuelve -1 si la lista está llena
    // Devuelve 0 si ha podido añadir el usuario a la lista
    if (lista->num == 100)
        return -1;
    else {
        strcpy(lista->conectados[lista->num].usuario, usuario);
        lista->conectados[lista->num].socket = socket;
        lista->num++;
        char conectados[300];
        DameConectados(lista, conectados);

        for (int i = 0; i < lista->num; i++) {
            send(lista->conectados[i].socket, conectados, strlen(conectados), 0);
        }

        return 0;
    }
}

>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
char* UsuarioDesdeSocket(ListaConectados *lista, int socket) { //Funcion para saber quien es el usuario actual
    for (int i = 0; i < lista->num; i++) {
        if (lista->conectados[i].socket == socket)
            return lista->conectados[i].usuario;
    }
    return NULL; // No encontrado
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
			i = i+1;	
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
			lista->conectados[pos].estado = 0;        // Marcamos como desconectado
			lista -> conectados[i] = lista -> conectados[i+1];

		}
		lista->num--;
		// Notificar a todos los conectados
        char conectados[300];
        DameConectados(lista, conectados);

        for (int i = 0; i < lista->num; i++) {
            send(lista->conectados[i].socket, conectados, strlen(conectados), 0);
        }
		return 0;
	}		
}

<<<<<<< HEAD
void DameConectados (ListaConectados *lista, char conectados [300]){
	//Pone en conectados los nombres de todos los conectados separados por /
	sprintf(conectados, "6/%d", lista->num);
	for (int i = 0; i < lista->num; i++) {
        strcat(conectados, "/");
        strcat(conectados, lista->conectados[i].usuario);
    }
=======
void ProcesarApuesta(MYSQL *conn, int id_jugador, int caballo_apostado, float apuesta, char resultado[200]) {
    MYSQL_RES *res;
    MYSQL_ROW row;
    char query[512];
    int id_partida;
    int caballo_ganador;
    float beneficio;
    char gano[20];
    int victorias = 0;
    float puntos;

    // Seleccionar partida aleatoria
    id_partida = 1 + rand() % 3;

    // Asignar jugador a la partida
    snprintf(query, sizeof(query), "UPDATE jugadores SET id_partida = %d WHERE id_jugador = %d;", id_partida, id_jugador);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al actualizar id_partida: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al asignar partida.");
        return;
    }

    // Obtener caballo ganador
    snprintf(query, sizeof(query), "SELECT caballo_ganador FROM partidas WHERE id_partida = %d;", id_partida);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar caballo ganador: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar caballo ganador.");
        return;
    }
    res = mysql_store_result(conn);
    if (res == NULL) {
        fprintf(stderr, "Error al obtener resultado: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener datos del ganador.");
        return;
    }
    row = mysql_fetch_row(res);
    if (row == NULL) {
        fprintf(stderr, "No se pudo obtener el caballo ganador.\n");
        strcpy(resultado, "7/No se encontró caballo ganador.");
        mysql_free_result(res);
        return;
    }

    caballo_ganador = atoi(row[0]);
    mysql_free_result(res);

    // Obtener puntos del jugador
    snprintf(query, sizeof(query), "SELECT puntos FROM jugadores WHERE id_jugador = %d;", id_jugador);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar puntos del jugador: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar puntos del jugador.");
        return;
    }
    res = mysql_store_result(conn);
    if (res == NULL) {
        fprintf(stderr, "Error al obtener resultado de la consulta: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener resultado.");
        return;
    }
    row = mysql_fetch_row(res);
    if (row == NULL || row[0] == NULL) {
        fprintf(stderr, "No se encontró puntos para el jugador con id %d.\n", id_jugador);
        strcpy(resultado, "7/No se encontró puntos del jugador.");
        mysql_free_result(res);
        return;
    }

    puntos = atof(row[0]);
    mysql_free_result(res);

    // Calcular si ganó
    if (caballo_apostado == caballo_ganador) {
        strcpy(gano, "WIN");
        beneficio = apuesta * 2;
        victorias = 1;
		puntos= puntos + beneficio;
    } else {
        strcpy(gano, "LOSE");
        beneficio = -apuesta;
		puntos= puntos + beneficio;

    }

	//Actualiza los puntos del jugador
	snprintf(query, sizeof(query),
    	"UPDATE jugadores SET puntos = %.2f WHERE id_jugador = %d;", puntos, id_jugador);
	if (mysql_query(conn, query)) {
    	fprintf(stderr, "Error al actualizar puntos del jugador: %s\n", mysql_error(conn));
    	strcpy(resultado, "7/Error al actualizar puntos del jugador.");
    	return;
	}


    // Verificar existencia en historial
    snprintf(query, sizeof(query), "SELECT COUNT(*) FROM historial WHERE id_jugador = %d;", id_jugador);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar existencia en historial: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar historial.");
        return;
    }

    res = mysql_store_result(conn);
    row = mysql_fetch_row(res);
    int existe = atoi(row[0]);
    mysql_free_result(res);

    // Si no existe, lo insertamos
    if (existe == 0) {
        snprintf(query, sizeof(query),
            "INSERT INTO historial (id_jugador, partidas_jugadas, partidas_ganadas, beneficio_total) VALUES (%d, 1, %d, %.2f);", id_jugador, victorias, puntos);
    } else {
        // Si ya existe, lo actualizamos
        snprintf(query, sizeof(query),
            "UPDATE historial SET partidas_jugadas = partidas_jugadas + 1, "
            "partidas_ganadas = partidas_ganadas + %d, "
            "beneficio_total =  %.2f "
            "WHERE id_jugador = %d;", victorias, puntos, id_jugador);
    }

    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al insertar/actualizar historial: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al insertar/actualizar historial.");
        return;
    }

    // Consultar beneficio actualizado
    snprintf(query, sizeof(query), "SELECT beneficio_total FROM historial WHERE id_jugador = %d;", id_jugador);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar beneficio: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar beneficio.");
        return;
    }

    res = mysql_store_result(conn);
    if (res == NULL) {
        fprintf(stderr, "Error al obtener resultado del beneficio: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener beneficio.");
        return;
    }

    row = mysql_fetch_row(res);
    if (row == NULL) {
        fprintf(stderr, "No se encontró beneficio del jugador.\n");
        strcpy(resultado, "7/Beneficio no disponible.");
        mysql_free_result(res);
        return;
    }

    float puntos_actuales = atof(row[0]);
    mysql_free_result(res);

    // Enviar respuesta al cliente
    sprintf(resultado, "%d/%s/%.2f/%.2f", caballo_ganador, gano, beneficio, puntos_actuales);
    printf("Mensaje enviado al cliente: %s\n", resultado);
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
}
void ProcesarApuestasEnPartida(MYSQL *conn, const char *username, char resultado[256]) {
    MYSQL_RES *res;
    MYSQL_ROW row;
    char query[512];
    int id_partida;
    int caballo_ganador;

    // 1️ Obtener id_partida del jugador por su username
    snprintf(query, sizeof(query), 
             "SELECT id_partida FROM jugadores WHERE username = '%s';", username);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al obtener id_partida: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener id_partida.");
        return;
    }

    res = mysql_store_result(conn);
    if ((row = mysql_fetch_row(res)) == NULL) {
        strcpy(resultado, "7/No se encontró id_partida.");
        mysql_free_result(res);
        return;
    }
    id_partida = atoi(row[0]);
    mysql_free_result(res);

    // 2️ Obtener caballo_ganador de la partida
    snprintf(query, sizeof(query), 
             "SELECT caballo_ganador FROM partidas WHERE id_partida = %d;", id_partida);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al obtener caballo ganador: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener caballo ganador.");
        return;
    }

    res = mysql_store_result(conn);
    if ((row = mysql_fetch_row(res)) == NULL) {
        strcpy(resultado, "7/No se encontró caballo ganador.");
        mysql_free_result(res);
        return;
    }
    caballo_ganador = atoi(row[0]);
    mysql_free_result(res);

    // 3️ Obtener todos los jugadores de la partida
    snprintf(query, sizeof(query), 
             "SELECT id_jugador, username, apuesta, caballo_elegido, puntos "
             "FROM jugadores WHERE id_partida = %d;", id_partida);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al obtener jugadores: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener jugadores.");
        return;
    }

    res = mysql_store_result(conn);
    int num_jugadores = mysql_num_rows(res);
    if (num_jugadores < 2) {
        strcpy(resultado, "7/No hay suficientes jugadores para jugar.");
        mysql_free_result(res);
        return;
    }

    // Guardar jugadores en arrays temporales
    int id_jugadores[num_jugadores];
    char usernames[num_jugadores][50];
    float apuestas[num_jugadores];
    int caballos[num_jugadores];
    float puntos[num_jugadores];
	int victorias[num_jugadores];

    int i = 0;
    while ((row = mysql_fetch_row(res))) {
        id_jugadores[i] = atoi(row[0]);
        strncpy(usernames[i], row[1], sizeof(usernames[i])-1);
        apuestas[i] = atof(row[2]);
        caballos[i] = atoi(row[3]);
        puntos[i] = atof(row[4]);
		victorias[i] = 0;
        i++;
    }
    mysql_free_result(res);

    // 4️ Procesar apuestas por parejas (sin repetición)
    for (i = 0; i < num_jugadores - 1; i++) {
        for (int j = i + 1; j < num_jugadores; j++) {
            int acierta_i = (caballos[i] == caballo_ganador);
            int acierta_j = (caballos[j] == caballo_ganador);
            float beneficio_i = 0.0;
            float beneficio_j = 0.0;

            if (caballos[i] == caballos[j]) {
                if (acierta_i) {
                    beneficio_i = 0.0;
                    beneficio_j = 0.0;
					victorias[i]++;
					victorias[j]++;
                } else {
                    beneficio_i = -apuestas[i];
                    beneficio_j = -apuestas[j];
                }
            } else {
                if (acierta_i && !acierta_j) {
                    beneficio_i = apuestas[j];
                    beneficio_j = -apuestas[j];
					victorias[i]++;					
                } else if (!acierta_i && acierta_j) {
                    beneficio_i = -apuestas[i];
                    beneficio_j = apuestas[i];
					victorias[j]++;
                } else {
                    beneficio_i = -apuestas[i];
                    beneficio_j = -apuestas[j];
                }
            }

            // Aplicar beneficios a los jugadores
            puntos[i] += beneficio_i;
            puntos[j] += beneficio_j;

            // Actualizar historial de cada jugador
            for (int i = 0; i < num_jugadores; i++) {
				int id_jugador_actual = id_jugadores[i];
				int victorias_actual = victorias[i];
				float puntos_actual = puntos[i];

				// Verificar existencia en historial
				snprintf(query, sizeof(query), "SELECT COUNT(*) FROM historial WHERE id_jugador = %d;", id_jugador_actual);
				if (mysql_query(conn, query)) {
					fprintf(stderr, "Error al consultar existencia en historial: %s\n", mysql_error(conn));
					strcpy(resultado, "7/Error al consultar historial.");
					return;
				}

				res = mysql_store_result(conn);
				row = mysql_fetch_row(res);
				int existe = atoi(row[0]);
				mysql_free_result(res);

				// Insertar o actualizar historial
				if (existe == 0) {
					snprintf(query, sizeof(query),
						"INSERT INTO historial (id_jugador, partidas_jugadas, partidas_ganadas, beneficio_total) "
						"VALUES (%d, 1, %d, %.2f);",
						id_jugador_actual, victorias_actual, puntos_actual);
				} else {
					snprintf(query, sizeof(query),
						"UPDATE historial "
						"SET partidas_jugadas = partidas_jugadas + 1, "
						"partidas_ganadas = partidas_ganadas + %d, "
						"beneficio_total = %.2f "
						"WHERE id_jugador = %d;",
						victorias_actual, puntos_actual, id_jugador_actual);
				}

				if (mysql_query(conn, query)) {
					fprintf(stderr, "Error al insertar/actualizar historial: %s\n", mysql_error(conn));
					strcpy(resultado, "7/Error al insertar/actualizar historial.");
					return;
				}
			}
        }
    }

    // 5️ Actualizar puntos finales en la base de datos
    for (i = 0; i < num_jugadores; i++) {
        snprintf(query, sizeof(query),
            "UPDATE jugadores SET puntos = %.2f WHERE id_jugador = %d;",
            puntos[i], id_jugadores[i]);
        if (mysql_query(conn, query)) {
            fprintf(stderr, "Error al actualizar puntos: %s\n", mysql_error(conn));
        }
    }

    // 6️ Armar resultado
   snprintf(resultado, 1000, "%d", caballo_ganador);
	for (i = 0; i < num_jugadores; i++) {
    	char buffer[200];
    	snprintf(buffer, sizeof(buffer), "/%s/%.2f", usernames[i], puntos[i]);
    	strcat(resultado, buffer);
	}

}



void ProcesarApuesta(MYSQL *conn, int id_jugador, int caballo_apostado, float apuesta, char resultado[200]) {
    MYSQL_RES *res;
    MYSQL_ROW row;
    char query[512];
    int id_partida;
    int caballo_ganador;
    float beneficio;
    char gano[20];
    int victorias = 0;
    float puntos;

    // Obtener id de la partida a partir del jugador
    snprintf(query, sizeof(query), "SELECT id_partida FROM jugadores WHERE id_jugador = %d;", id_jugador);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar id de la partida: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar id de la partida.");
        return;
    }
    res = mysql_store_result(conn);
    if (res == NULL) {
        fprintf(stderr, "Error al obtener resultado: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener los datos.");
        return;
    }
    row = mysql_fetch_row(res);
    if (row == NULL) {
        fprintf(stderr, "No se pudo obtener el id de la partida.\n");
        strcpy(resultado, "7/No se encontró el id de la partida.");
        mysql_free_result(res);
        return;
    }

    id_partida = atoi(row[0]);
    mysql_free_result(res);

    // Obtener caballo ganador
    snprintf(query, sizeof(query), "SELECT caballo_ganador FROM partidas WHERE id_partida = %d;", id_partida);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar caballo ganador: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar caballo ganador.");
        return;
    }
    res = mysql_store_result(conn);
    if (res == NULL) {
        fprintf(stderr, "Error al obtener resultado: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener datos del ganador.");
        return;
    }
    row = mysql_fetch_row(res);
    if (row == NULL) {
        fprintf(stderr, "No se pudo obtener el caballo ganador.\n");
        strcpy(resultado, "7/No se encontró caballo ganador.");
        mysql_free_result(res);
        return;
    }

    caballo_ganador = atoi(row[0]);
    mysql_free_result(res);

    // Obtener puntos del jugador
    snprintf(query, sizeof(query), "SELECT puntos FROM jugadores WHERE id_jugador = %d;", id_jugador);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar puntos del jugador: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar puntos del jugador.");
        return;
    }
    res = mysql_store_result(conn);
    if (res == NULL) {
        fprintf(stderr, "Error al obtener resultado de la consulta: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener resultado.");
        return;
    }
    row = mysql_fetch_row(res);
    if (row == NULL || row[0] == NULL) {
        fprintf(stderr, "No se encontró puntos para el jugador con id %d.\n", id_jugador);
        strcpy(resultado, "7/No se encontró puntos del jugador.");
        mysql_free_result(res);
        return;
    }

    puntos = atof(row[0]);
    mysql_free_result(res);

    // Calcular si ganó
    if (caballo_apostado == caballo_ganador) {
        strcpy(gano, "WIN");
        beneficio = apuesta * 2;
        victorias = 1;
		puntos= puntos + beneficio;
    } else {
        strcpy(gano, "LOSE");
        beneficio = -apuesta;
		puntos= puntos + beneficio;

    }

	//Actualiza los puntos del jugador
	snprintf(query, sizeof(query),
    	"UPDATE jugadores SET puntos = %.2f WHERE id_jugador = %d;", puntos, id_jugador);
	if (mysql_query(conn, query)) {
    	fprintf(stderr, "Error al actualizar puntos del jugador: %s\n", mysql_error(conn));
    	strcpy(resultado, "7/Error al actualizar puntos del jugador.");
    	return;
	}


    // Verificar existencia en historial
    snprintf(query, sizeof(query), "SELECT COUNT(*) FROM historial WHERE id_jugador = %d;", id_jugador);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar existencia en historial: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar historial.");
        return;
    }

    res = mysql_store_result(conn);
    row = mysql_fetch_row(res);
    int existe = atoi(row[0]);
    mysql_free_result(res);

    // Si no existe, lo insertamos
    if (existe == 0) {
        snprintf(query, sizeof(query),
            "INSERT INTO historial (id_jugador, partidas_jugadas, partidas_ganadas, beneficio_total) VALUES (%d, 1, %d, %.2f);", id_jugador, victorias, puntos);
    } else {
        // Si ya existe, lo actualizamos
        snprintf(query, sizeof(query),
            "UPDATE historial SET partidas_jugadas = partidas_jugadas + 1, "
            "partidas_ganadas = partidas_ganadas + %d, "
            "beneficio_total =  %.2f "
            "WHERE id_jugador = %d;", victorias, puntos, id_jugador);
    }

    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al insertar/actualizar historial: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al insertar/actualizar historial.");
        return;
    }

    // Consultar beneficio actualizado
    snprintf(query, sizeof(query), "SELECT beneficio_total FROM historial WHERE id_jugador = %d;", id_jugador);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al consultar beneficio: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al consultar beneficio.");
        return;
    }

    res = mysql_store_result(conn);
    if (res == NULL) {
        fprintf(stderr, "Error al obtener resultado del beneficio: %s\n", mysql_error(conn));
        strcpy(resultado, "7/Error al obtener beneficio.");
        return;
    }

    row = mysql_fetch_row(res);
    if (row == NULL) {
        fprintf(stderr, "No se encontró beneficio del jugador.\n");
        strcpy(resultado, "7/Beneficio no disponible.");
        mysql_free_result(res);
        return;
    }

    float puntos_actuales = atof(row[0]);
    mysql_free_result(res);

    // Enviar respuesta al cliente
    sprintf(resultado, "%d/%s/%.2f/%.2f", caballo_ganador, gano, beneficio, puntos_actuales);
    printf("Mensaje enviado al cliente: %s\n", resultado);

	int nuevo_caballo_ganador = (rand() % 3) + 1;

	//Actualiza el caballo ganador
	snprintf(query, sizeof(query),
    	"UPDATE partidas SET caballo_ganador = %d WHERE id_partida = %d;", nuevo_caballo_ganador, id_partida);
	if (mysql_query(conn, query)) {
    	fprintf(stderr, "Error al actualizar el caballo ganador: %s\n", mysql_error(conn));
    	strcpy(resultado, "7/Error al actualizar el caballo ganador.");
    	return;
	}
}
void ProcesarApuestasEnPartida(ListaConectados *lista, MYSQL *conn, const char *username, int *caballo_ganador) {
    MYSQL_RES *res;
    MYSQL_ROW row;
    char query[512];
    int id_partida;
    char resultado_partida[20];

    // 1️ Obtener id_partida del jugador por su username
    snprintf(query, sizeof(query),
             "SELECT id_partida FROM jugadores WHERE username = '%s';", username);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al obtener id_partida: %s\n", mysql_error(conn));
        return;
    }

    res = mysql_store_result(conn);
    if ((row = mysql_fetch_row(res)) == NULL) {
        mysql_free_result(res);
        return;
    }
    id_partida = atoi(row[0]);
    mysql_free_result(res);

    // 2️ Obtener caballo_ganador de la partida
    snprintf(query, sizeof(query),
             "SELECT caballo_ganador FROM partidas WHERE id_partida = %d;", id_partida);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al obtener caballo ganador: %s\n", mysql_error(conn));
        return;
    }

    res = mysql_store_result(conn);
    if ((row = mysql_fetch_row(res)) == NULL) {
        mysql_free_result(res);
        return;
    }
    *caballo_ganador = atoi(row[0]);
    mysql_free_result(res);

    // 3️ Obtener todos los jugadores de la partida
    snprintf(query, sizeof(query),
             "SELECT id_jugador, username, apuesta, caballo_elegido, puntos "
             "FROM jugadores WHERE id_partida = %d;", id_partida);
    if (mysql_query(conn, query)) {
        fprintf(stderr, "Error al obtener jugadores: %s\n", mysql_error(conn));
        return;
    }

    res = mysql_store_result(conn);
    int num_jugadores = mysql_num_rows(res);
    if (num_jugadores < 2) {
        mysql_free_result(res);
        return;
    }

    // Guardar jugadores en arrays temporales
    int id_jugadores[num_jugadores];
    char usernames[num_jugadores][20];
    float apuestas[num_jugadores];
    int caballos[num_jugadores];
    float puntos[num_jugadores];
    int victorias[num_jugadores];
	float beneficio_neto[num_jugadores];

    int i = 0;
    while ((row = mysql_fetch_row(res))) {
        id_jugadores[i] = atoi(row[0]);
        strncpy(usernames[i], row[1], sizeof(usernames[i])-1);
        usernames[i][sizeof(usernames[i])-1] = '\0';  // Por seguridad
        apuestas[i] = atof(row[2]);
        caballos[i] = atoi(row[3]);
        puntos[i] = atof(row[4]);
        victorias[i] = 0;
        i++;
    }
    mysql_free_result(res);

    // 4️ Procesar apuestas de forma individual
    float total_apostado = 0.0;
    int num_ganadores = 0;
	

    // Suma total apostado y cuenta ganadores
    for (i = 0; i < num_jugadores; i++) {
        total_apostado += apuestas[i];
        if (caballos[i] == *caballo_ganador) {
            num_ganadores++;
        }
    }

    // 5️ Repartir beneficios/pérdidas
    if (num_ganadores > 0) {
        float bote_ganadores = total_apostado / num_ganadores;
        for (i = 0; i < num_jugadores; i++) {
            if (caballos[i] == *caballo_ganador) {
                puntos[i] += bote_ganadores;  // Gana el bote compartido
                victorias[i]++;
				beneficio_neto[i] = apuestas[i];  //Guarda el beneficio
            } else {
                puntos[i] -= apuestas[i];  // Pierde su apuesta
				beneficio_neto[i] = -apuestas[i];
            }
        }
    } else {
        // Nadie acertó: todos pierden su apuesta
        for (i = 0; i < num_jugadores; i++) {
            puntos[i] -= apuestas[i];
			beneficio_neto[i] = -apuestas[i];
        }
    }

    // 6️ Actualizar historial y lista de conectados
    for (i = 0; i < num_jugadores; i++) {
        int id_jugador_actual = id_jugadores[i];
        float puntos_actual = puntos[i];
        int victorias_actual = victorias[i];

        if (victorias_actual > 0)
            strcpy(resultado_partida, "WIN");
        else
            strcpy(resultado_partida, "LOSE");

        // Actualizar lista de conectados
        for (int k = 0; k < lista->num; k++) {
            if (lista->conectados[k].estado == 1 && lista->conectados[k].id_partida == id_partida) {
                if (strcmp(lista->conectados[k].usuario, usernames[i]) == 0) {
                    strcpy(lista->conectados[k].resultado_partida, resultado_partida);
                    lista->conectados[k].beneficio_partida = beneficio_neto[i];
                }
            }
        }

        // Verificar si el jugador tiene historial
        snprintf(query, sizeof(query),
                 "SELECT COUNT(*) FROM historial WHERE id_jugador = %d;", id_jugador_actual);
        if (mysql_query(conn, query)) {
            fprintf(stderr, "Error al consultar historial: %s\n", mysql_error(conn));
            return;
        }

        res = mysql_store_result(conn);
        row = mysql_fetch_row(res);
        int existe = atoi(row[0]);
        mysql_free_result(res);

        // Insertar o actualizar historial
        if (existe == 0) {
            snprintf(query, sizeof(query),
                     "INSERT INTO historial (id_jugador, partidas_jugadas, partidas_ganadas, beneficio_total) "
                     "VALUES (%d, 1, %d, %.2f);",
                     id_jugador_actual, victorias_actual, puntos_actual);
        } else {
            snprintf(query, sizeof(query),
                     "UPDATE historial "
                     "SET partidas_jugadas = partidas_jugadas + 1, "
                     "partidas_ganadas = partidas_ganadas + %d, "
                     "beneficio_total = beneficio_total + %.2f "
                     "WHERE id_jugador = %d;",
                     victorias_actual, beneficio_neto[i], id_jugador_actual);
        }

        if (mysql_query(conn, query)) {
            fprintf(stderr, "Error al actualizar historial: %s\n", mysql_error(conn));
            return;
        }
    }

    // 7️ Actualizar puntos finales en la base de datos
    for (i = 0; i < num_jugadores; i++) {
        snprintf(query, sizeof(query),
                 "UPDATE jugadores SET puntos = %.2f WHERE id_jugador = %d;",
                 puntos[i], id_jugadores[i]);
        if (mysql_query(conn, query)) {
            fprintf(stderr, "Error al actualizar puntos: %s\n", mysql_error(conn));
        }
    }

	int nuevo_caballo_ganador = (rand() % 3) + 1;

	//Actualiza el caballo ganador
	snprintf(query, sizeof(query),
    	"UPDATE partidas SET caballo_ganador = %d WHERE id_partida = %d;", nuevo_caballo_ganador, id_partida);
	if (mysql_query(conn, query)) {
    	fprintf(stderr, "Error al actualizar el caballo ganador: %s\n", mysql_error(conn));
    	return;
	}
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
	char consulta[256];
	char insertar[256];
	char ubdate[256];
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error al crear conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	conn = mysql_real_connect(conn, "shiva2.upc.es", "root", "mysql", "T5_BDCarreraDeCaballos", 0 , NULL, 0);
	if (conn == NULL) {
		printf("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	err = mysql_query(conn, "USE T5_BDCarreraDeCaballos;");
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
			float puntos;
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
				if (p != NULL) 
					puntos = atof(p);
				p = strtok(NULL, "/");
				if (p != NULL) 
					edad = atoi(p);  
				
				printf("Codigo: %d, username: %s, password_p: %s, puntos: %.2f, edad: %d\n", codigo, username, password, puntos, edad);
			}
			
			if (codigo == 0) {
				pthread_mutex_lock(&mutex);
				Eliminar(&miLista, username);
				pthread_mutex_unlock(&mutex);
				printf("0/Usuario desconectado: %s\n", username);
				snprintf(consulta, sizeof(consulta), 
					"UPDATE jugadores SET id_partida = NULL, caballo_elegido = NULL, apuesta = NULL WHERE username = '%s';", 
					username);
				if (mysql_query(conn, consulta)) {
					printf("Error al actualizar id_partida: %s\n", mysql_error(conn));
				}
				sprintf(respuesta, "0/Usuario desconectado: %s\n", username);
				send(sock_conn, respuesta, strlen(respuesta), 0);
<<<<<<< HEAD
			} 

			else if (codigo == 1) {  //INICIAR SESION
				int id_partida;
				int usuario_correcto = 0;
				char username_confirmado[50] = "";

				sprintf(consulta, "SELECT username, password_p FROM jugadores WHERE username =  '%s' AND password_p =  '%s'", username, password);
=======
				//INICIAR SESION
			} else if (codigo == 1) {
				sprintf(consulta, "SELECT username, password_p FROM jugadores WHERE username =  '%s' AND password_p =  '%s'",username,password);
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
				printf("Consulta SQL: %s\n", consulta);
				err = mysql_query(conn, consulta);
				if (err != 0) {
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
<<<<<<< HEAD
				row = mysql_fetch_row(resultado);
				if (row != NULL) {
					usuario_correcto = 1;
					strcpy(username_confirmado, row[0]);
				}
				mysql_free_result(resultado);

				float ben = 0.0;
				if (usuario_correcto) {
					// Obtener puntos
=======
				if (resultado == NULL) {
					printf("Error al obtener el resultado: %s\n", mysql_error(conn));
					exit(1);
				} else {
					int num_rows = mysql_num_rows(resultado);
					printf("Numero de filas devueltas: %d\n", num_rows);
				}
				row = mysql_fetch_row(resultado);
				
				float ben = 0.0;
				if (row != NULL) {
					// Obtener el beneficio total del usuario
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
					sprintf(consulta, "SELECT puntos FROM jugadores WHERE username = '%s'", username);
					err = mysql_query(conn, consulta);
					if (err == 0) {
						MYSQL_RES *res_ben = mysql_store_result(conn);
						MYSQL_ROW row_ben = mysql_fetch_row(res_ben);
						if (row_ben && row_ben[0]) {
							ben = atof(row_ben[0]);
						}
						mysql_free_result(res_ben);
					}
<<<<<<< HEAD

					// Obtener edad
					snprintf(consulta, sizeof(consulta),
							"SELECT edad FROM jugadores WHERE username = '%s';", username);
					if (mysql_query(conn, consulta)) {
						printf("Error al consultar edad: %s\n", mysql_error(conn));
					}
					resultado = mysql_store_result(conn);
					row = mysql_fetch_row(resultado);
					if (row) {
						int edad_jugador = atoi(row[0]);
						mysql_free_result(resultado);

						// Obtener partidas válidas
						snprintf(consulta, sizeof(consulta),
								"SELECT id_partida FROM partidas WHERE limite_edad <= %d;", edad_jugador);
						if (mysql_query(conn, consulta)) {
							printf("Error al obtener partidas válidas: %s\n", mysql_error(conn));
						}
						resultado = mysql_store_result(conn);

						int num_partidas = mysql_num_rows(resultado);
						if (num_partidas == 0) {
							printf("No hay partidas válidas para el jugador.\n");
						} else {
							int partidas[num_partidas];
							int i = 0;
							while ((row = mysql_fetch_row(resultado))) {
								partidas[i] = atoi(row[0]);
								i++;
							}
							mysql_free_result(resultado);

							// Elegir aleatoria
							int random_index = rand() % num_partidas;
							id_partida = partidas[random_index];

							// Asignar la partida
							snprintf(consulta, sizeof(consulta),
									"UPDATE jugadores SET id_partida = %d WHERE username = '%s';",
									id_partida, username);
							if (mysql_query(conn, consulta)) {
								printf("Error al actualizar id_partida: %s\n", mysql_error(conn));
							}
						}
					} else {
						printf("No se encontró la edad del jugador.\n");
						mysql_free_result(resultado);
					}
				}

				// Mutex y conectar
				pthread_mutex_lock(&mutex);
				PonConectado(&miLista, username, sock_conn, id_partida);
				pthread_mutex_unlock(&mutex);

				if (!usuario_correcto) {
					sprintf(respuesta, "1/El usuario y/o la contraseña no son correctos\n");
				} else {
					sprintf(respuesta, "1/Se ha iniciado sesion correctamente, bienvenido %s/%.2f/%d\n", username_confirmado, ben, id_partida);
=======
				}
				
				pthread_mutex_lock(&mutex);
				PonConectado(&miLista, username, sock_conn); 
				pthread_mutex_unlock(&mutex);

				if (row == NULL) {
					sprintf(respuesta,"1/El usuario y/o la contraseña no son correctos\n");
				} else {
					sprintf(respuesta,"1/Se ha iniciado sesion correctamente, bienvenido %s/%.2f\n", row[0],ben);
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
				}
				printf("%s", respuesta);
				send(sock_conn, respuesta, strlen(respuesta), 0);
				printf("Usuario conectado: %s\n", username);
<<<<<<< HEAD
			}

 			else if (codigo == 2) { //Registrarse
=======

				// Seleccionar partida aleatoria
    			int id_partida = 1 + rand() % 3;
				snprintf(consulta, sizeof(consulta), 
					"UPDATE jugadores SET id_partida = '%d' WHERE username = '%s';", 
					id_partida, username);
				if (mysql_query(conn, consulta)) {
					printf("Error al actualizar id_partida: %s\n", mysql_error(conn));
				}

				//Registar
			} else if (codigo == 2) {
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
				sprintf(insertar, "INSERT INTO jugadores ( username, password_p, puntos, edad, id_partida) VALUES ('%s', '%s', '%.2f','%d',NULL);",
						username, password, puntos, edad);		
				printf("Consulta SQL para insertar: %s\n", insertar);
				err = mysql_query(conn, insertar);
				if (err != 0) {
					printf("Error MySQL: %u - %s\n", mysql_errno(conn), mysql_error(conn));
					sprintf(respuesta, "2/Error al insertar datos en la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				else{
					if (mysql_affected_rows(conn) > 0) {
<<<<<<< HEAD
						sprintf(respuesta, "2/Usuario registrado correctamente: %s\n Ya puedes iniciar la sesion", username);
=======
						sprintf(respuesta, "2/Usuario registrado correctamente: %s\n", username);
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
					} else {
						sprintf(respuesta, "2/No se pudo registrar el usuario.\n");
					}
				}
<<<<<<< HEAD
=======
				//sprintf(insertar, "INSERT INTO historial (puntos) VALUES ('%.2f', NULL);", puntos );
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
				send(sock_conn, respuesta, strlen(respuesta), 0);
			} //Consulta el historial 
			
			else if(codigo==3){
				char usuario[20];
				int id_jugador;
				char *c = strtok(NULL, "/");
				strcpy(usuario,c);
				printf("Usuario del jugador extraido: %s\n", usuario);  // Verifica el usuario extraido
				printf("Dame el nombre de usuario que quieres consultar su historial\n");
				sprintf(consulta, "SELECT id_jugador FROM jugadores WHERE username = '%s'", usuario);
				err = mysql_query(conn, consulta); 
				if (err != 0) {
					printf( "Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
				if ((row = mysql_fetch_row(resultado)) != NULL)
				{
					id_jugador = atoi(row[0]);
				} else {
					int num_rows = mysql_num_rows(resultado);
					printf("Numero de filas devueltas: %d\n", num_rows);
				}
				mysql_free_result(resultado);
				sprintf (consulta,"SELECT * FROM historial WHERE id_jugador = '%d'", id_jugador);
				printf("Consulta generada: %s\n", consulta); 
				err = mysql_query(conn, consulta);
				if (err != 0) {
					printf( "Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
				if (resultado == NULL) {
					printf("Error al obtener el resultado: %s\n", mysql_error(conn));
					exit(1);
				} else {
					int num_rows = mysql_num_rows(resultado);
					printf("Numero de filas devueltas: %d\n", num_rows);
				}
				row = mysql_fetch_row(resultado);
				
				if (row == NULL) {
					sprintf(respuesta, "3/No se han obtenido datos\n");
				} else {
					sprintf(respuesta, "3/Partidas jugadas: %s, Partidas ganadas: %s, Beneficio total: %s, id_jugador: %s", row[0], row[1], row[2],row[3]);
				}
				printf("3/%s", respuesta);
				send(sock_conn, respuesta, strlen(respuesta), 0);
			}
<<<<<<< HEAD
			else if (codigo == 4) { //Consulta la duracion de la partida
=======
			else if (codigo == 4) {
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
				char id_partida[80];
				char *c = strtok(NULL, "/");
				strcpy (id_partida,c);
				printf("ID de partida recibido: %s\n", id_partida);
				
				sprintf(consulta, "SELECT duracion FROM partidas WHERE id_partida = '%d'", atoi (id_partida));
				printf("Consulta ejecutada: [%s]\n", consulta);
				err = mysql_query(conn, consulta);
				printf("Resultado de mysql_query: %d\n", err);				
				if (err != 0) {
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result(conn);
				if (resultado == NULL) {
					printf("Error al obtener el resultado: %s\n", mysql_error(conn));
					exit(1);
				} else {
					int num_rows = mysql_num_rows(resultado);
					printf("Numero de filas devueltas: %d\n", num_rows);
					if (num_rows > 0) {
					row = mysql_fetch_row(resultado);
					if (row) {
						printf("Duracion de la partida obtenida: %s\n", row[0]);
						sprintf(respuesta, "4/Duracion de la partida: %s\n", row[0]);
					} else {
						printf("Error al obtener la fila.\n");
					}
					printf("4/%s", respuesta);
				}
				}
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
				if (resultado == NULL) {
					printf("Error al obtener el resultado: %s\n", mysql_error(conn));
					exit(1);
				} else {
					int num_rows = mysql_num_rows(resultado);
					printf("Numero de filas devueltas: %d\n", num_rows);
					if (num_rows > 0) {
<<<<<<< HEAD
						row = mysql_fetch_row(resultado);
						if (row) {
							printf("Duracion de la partida obtenida: %s\n", row[0]);
							sprintf(respuesta, "5/Duracion de la partida: %s\n", row[0]);
						} else {
							printf("Error al obtener la fila.\n");
						}
						printf("5/%s", respuesta);
=======
					row = mysql_fetch_row(resultado);
					if (row) {
						printf("Duracion de la partida obtenida: %s\n", row[0]);
						sprintf(respuesta, "5/Duracion de la partida: %s\n", row[0]);
					} else {
						printf("Error al obtener la fila.\n");
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
					}
					printf("5/%s", respuesta);
				}
<<<<<<< HEAD
=======
				}
				
				
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
				printf("5/%s", respuesta);
				send(sock_conn, respuesta, strlen(respuesta), 0);
			}
			else if (codigo == 6) {  //Notificacion lista conectados
				char conectados[300];
				pthread_mutex_lock(&mutex);
				DameConectados(&miLista, conectados);
<<<<<<< HEAD
				for (int k = 0; k < miLista.num; k++) {
					if (miLista.conectados[k].estado == 1){
						send(miLista.conectados[k].socket, conectados, strlen(conectados), 0);
					}
				}
				pthread_mutex_unlock(&mutex);
				
			}
			else if (codigo == 7) {  // Código para procesar la apuesta
				int caballo_apostado = -1;
				float apuesta = -1.0;
				char usuario[20];
				p = strtok(NULL, "/");
				if (p != NULL) caballo_apostado = atoi(p);
				p = strtok(NULL, "/");
				if (p != NULL) apuesta = atof(p);
				p = strtok(NULL, "/"); 
				if (p != NULL) strcpy(usuario, p);

				// Validar entrada
				if (caballo_apostado < 1 || apuesta <= 0) {
					char error[] = "7/Error: datos de apuesta inválidos.";
					send(sock_conn, error, strlen(error), 0);
					
				}

				printf("Apuesta recibida: caballo %d, apuesta %.2f\n", caballo_apostado, apuesta);

				snprintf(consulta, sizeof(consulta), 
					"UPDATE jugadores SET caballo_elegido = %d, apuesta = %.2f WHERE username = '%s';", 
					caballo_apostado, apuesta, usuario);

				if (mysql_query(conn, consulta)) {
					printf("Error al actualizar apuesta: %s\n", mysql_error(conn));
				}

				char respuesta_aux[200];
				char respuesta[250];
				int id_jugador = -1;

				if (usuario != NULL) {
					// Buscar ID del jugador en la base de datos
					char consulta[256];
					sprintf(consulta, "SELECT id_jugador FROM jugadores WHERE username = '%s'", usuario);

					pthread_mutex_lock(&mutex);  // Protege el acceso a la BD
					int err = mysql_query(conn, consulta);
					if (!err) {
						MYSQL_RES *res = mysql_store_result(conn);
						if (res != NULL) {
							MYSQL_ROW row = mysql_fetch_row(res);
							if (row != NULL) {
								id_jugador = atoi(row[0]);
							} else {
								fprintf(stderr, "Usuario no encontrado en la base de datos.\n");
							}
							mysql_free_result(res);
						} else {
							fprintf(stderr, "Error al obtener resultado de ID: %s\n", mysql_error(conn));
						}
					} else {
						fprintf(stderr, "Error en la consulta SQL de ID: %s\n", mysql_error(conn));
					}

					// Si se obtuvo el ID del jugador, procesar apuesta
					if (id_jugador != -1) {
						ProcesarApuesta(conn, id_jugador, caballo_apostado, apuesta, respuesta_aux);
						sprintf(respuesta,"7/%s",respuesta_aux);
						send(sock_conn, respuesta, strlen(respuesta), 0);
					} else {
						char error[] = "7/Error al obtener ID del jugador.";
						send(sock_conn, error, strlen(error), 0);
					}

					pthread_mutex_unlock(&mutex);
				} else {
					char error[] = "7/Error al identificar usuario desde socket.";
					send(sock_conn, error, strlen(error), 0);
				}
			}

			else if (codigo == 8) { // Código para invitar a otro usuario
				char usuario_invitador[50];
				char usuario_invitado[50];
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(usuario_invitador, p);
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(usuario_invitado, p);

				int socket_invitador = -1;
				pthread_mutex_lock(&mutex);
				for (int i = 0; i < miLista.num; i++) {
					if (strcmp(miLista.conectados[i].usuario, usuario_invitador) == 0) {
						socket_invitador = miLista.conectados[i].socket;
						break;
					}
				}
				pthread_mutex_unlock(&mutex);

				int socket_invitado = -1;
				pthread_mutex_lock(&mutex);
				for (int i = 0; i < miLista.num; i++) {
					if (strcmp(miLista.conectados[i].usuario, usuario_invitado) == 0) {
						socket_invitado = miLista.conectados[i].socket;
						break;
					}
				}
				pthread_mutex_unlock(&mutex);

				if (socket_invitado != -1 && socket_invitador != -1) {
					char consulta[256];
					// 1. Obtener id_partida del invitador
					sprintf(consulta, "SELECT id_partida FROM jugadores WHERE username = '%s'", usuario_invitador);
					err = mysql_query(conn, consulta);
					if (err != 0) {
						printf("Error al consultar la partida del invitador: %u %s\n", mysql_errno(conn), mysql_error(conn));
						sprintf(respuesta, "8/Error al obtener la partida del invitador\n");
					} else {
						resultado = mysql_store_result(conn);
						if (resultado != NULL && mysql_num_rows(resultado) > 0) {
							row = mysql_fetch_row(resultado);
							int id_partida = atoi(row[0]);
							mysql_free_result(resultado);

							// 2. Obtener el limite_edad de la partida
							sprintf(consulta, "SELECT limite_edad FROM partidas WHERE id_partida = %d", id_partida);
							err = mysql_query(conn, consulta);
							if (err != 0) {
								printf("Error al consultar limite_edad: %u %s\n", mysql_errno(conn), mysql_error(conn));
								sprintf(respuesta, "8/Error al obtener el limite de edad de la partida\n");
							} else {
								resultado = mysql_store_result(conn);
								if (resultado != NULL && mysql_num_rows(resultado) > 0) {
									row = mysql_fetch_row(resultado);
									int limite_edad = atoi(row[0]);
									mysql_free_result(resultado);

									// 3. Obtener la edad del usuario invitado
									sprintf(consulta, "SELECT edad FROM jugadores WHERE username = '%s'", usuario_invitado);
									err = mysql_query(conn, consulta);
									if (err != 0) {
										printf("Error al consultar edad del invitado: %u %s\n", mysql_errno(conn), mysql_error(conn));
										sprintf(respuesta, "8/Error al obtener la edad del usuario invitado\n");
									} else {
										resultado = mysql_store_result(conn);
										if (resultado != NULL && mysql_num_rows(resultado) > 0) {
											row = mysql_fetch_row(resultado);
											int edad_invitado = atoi(row[0]);
											mysql_free_result(resultado);

											// 4. Verificar la edad del invitado contra el límite de edad de la partida
											if (edad_invitado >= limite_edad) {
													// 5. Enviar notificaciones
													char mensaje[256];
													sprintf(mensaje, "8/El usuario %s te ha invitado a la partida %d/%s/%s/%d\n", usuario_invitador, id_partida, usuario_invitador,usuario_invitado, id_partida);
													printf("El usuario: %s puede jugar en la parida invitada. %s", usuario_invitado, mensaje);
													send(socket_invitado, mensaje, strlen(mensaje), 0);

													sprintf(respuesta, "8/Invitacion enviada a %s\n", usuario_invitado);
													send(socket_invitador, respuesta, strlen(respuesta), 0);
												
											} else {
												sprintf(respuesta, "8/El usuario %s no cumple con la edad minima para unirse a esta partida\n", usuario_invitado);
												send(socket_invitador, respuesta, strlen(respuesta), 0);
											}
										} else {
											sprintf(respuesta, "8/No se pudo obtener la edad del usuario invitado\n");
											send(socket_invitador, respuesta, strlen(respuesta), 0);
										}
									}
								} else {
									sprintf(respuesta, "8/No se encontró la partida\n");
									send(socket_invitador, respuesta, strlen(respuesta), 0);
								}
							}
						} else {
							sprintf(respuesta, "8/No se encontró la partida del invitador\n");
							send(socket_invitador, respuesta, strlen(respuesta), 0);
						}
					}
				} else {
					sprintf(respuesta, "8/No se pudo invitar al usuario\n");
					send(socket_invitador, respuesta, strlen(respuesta), 0);
				}
			}

		else if (codigo == 9) { // Código para responder invitación
			char respuesta_invitacion[10], usuario_invitador[50], usuario_invitado[50];
			int id_partida;
			p = strtok(NULL, "/");
			if (p != NULL) strcpy(respuesta_invitacion, p); // "aceptar" o "rechazar"
			p = strtok(NULL, "/");
			if (p != NULL) strcpy(usuario_invitador, p);
			p = strtok(NULL, "/");
			if (p != NULL) strcpy(usuario_invitado, p);
			p = strtok(NULL, "/");
			if (p != NULL) id_partida = atoi(p);

			int socket_invitador = -1;
			pthread_mutex_lock(&mutex);
			for (int i = 0; i < miLista.num; i++) {
				if (strcmp(miLista.conectados[i].usuario, usuario_invitador) == 0) {
					socket_invitador = miLista.conectados[i].socket;
					break;
				}
			}
			pthread_mutex_unlock(&mutex);

			int socket_invitado = -1;
			pthread_mutex_lock(&mutex);
			for (int i = 0; i < miLista.num; i++) {
				if (strcmp(miLista.conectados[i].usuario, usuario_invitado) == 0) {
					socket_invitado = miLista.conectados[i].socket;
					break;
				}
			}
			pthread_mutex_unlock(&mutex);

			if (strcmp(respuesta_invitacion, "aceptar") == 0) {
				char consulta[256];
				sprintf(consulta, "UPDATE jugadores SET id_partida = %d WHERE username = '%s'", id_partida, usuario_invitado);
				err = mysql_query(conn, consulta);
				if (err == 0) {
					sprintf(respuesta, "9/1/Has aceptado la invitacion a la partida %d/%d\n", id_partida, id_partida);
					send(socket_invitado, respuesta, strlen(respuesta), 0);

					if (socket_invitador != -1) {
						sprintf(respuesta, "9/%s ha aceptado tu invitacion\n", usuario_invitado);
						send(socket_invitador, respuesta, strlen(respuesta), 0);
					}
				} else {
					sprintf(respuesta, "9/Error al unirte a la partida\n");
					send(socket_invitado, respuesta, strlen(respuesta), 0);
				}
			} else { // rechazo
				sprintf(respuesta, "9/0/Has rechazado la invitacion\n");
				send(socket_invitado, respuesta, strlen(respuesta), 0);

				if (socket_invitador != -1) {
					sprintf(respuesta, "9/%s ha rechazado tu invitacion\n", usuario_invitado);
					send(socket_invitador, respuesta, strlen(respuesta), 0);
				}
			}	
		}
		else if (codigo == 10){ //Codigo para el chat
			char usuario[50];
			char mensaje[256];

			p = strtok(NULL, "/"); // usuario
			if (p != NULL) strcpy(usuario, p);

			p = strtok(NULL, "/"); // mensaje
			if (p != NULL) strcpy(mensaje, p);

			char mensajeChat[512];
			sprintf(mensajeChat, "10/%s/%s", usuario, mensaje); // Código 10 es el que maneja el cliente para chat

			pthread_mutex_lock(&mutex);
			for (int i = 0; i < miLista.num; i++) {
				if (miLista.conectados[i].socket != sock_conn) {
					send(miLista.conectados[i].socket, mensajeChat, strlen(mensajeChat), 0);
				}
			}
			pthread_mutex_unlock(&mutex);
		}
		else if (codigo == 11) { // Código para guardar la apuesta
			char usuario[50];
			int caballo_elegido;
			float apuesta;

			p = strtok(NULL, "/"); // usuario
			if (p != NULL) strcpy(usuario, p);

			p = strtok(NULL, "/"); // caballo elegido
			if (p != NULL) caballo_elegido = atoi(p);

			p = strtok(NULL, "/"); // apuesta elegido
			if (p != NULL) apuesta = atof(p);

			snprintf(consulta, sizeof(consulta), 
					"UPDATE jugadores SET caballo_elegido = %d, apuesta = %.2f WHERE username = '%s';", 
					caballo_elegido, apuesta, usuario);

			if (mysql_query(conn, consulta)) {
				printf("Error al actualizar apuesta: %s\n", mysql_error(conn));
=======
				pthread_mutex_unlock(&mutex);
				send(sock_conn, conectados, strlen(conectados), 0);
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
			}
			else if (codigo == 7) {  // Código para procesar la apuesta
				int caballo_apostado = -1;
				float apuesta = -1.0;
				p = strtok(NULL, "/");
				if (p != NULL) caballo_apostado = atoi(p);
				p = strtok(NULL, "/");
				if (p != NULL) apuesta = atof(p);

				// Validar entrada
				if (caballo_apostado < 1 || apuesta <= 0) {
					char error[] = "7/Error: datos de apuesta inválidos.";
					send(sock_conn, error, strlen(error), 0);
					
				}

				printf("Apuesta recibida: caballo %d, apuesta %.2f\n", caballo_apostado, apuesta);

				char respuesta_aux[200];
				char respuesta[250];
				char *usuario = UsuarioDesdeSocket(&miLista, sock_conn);
				int id_jugador = -1;

				if (usuario != NULL) {
					// Buscar ID del jugador en la base de datos
					char consulta[256];
					sprintf(consulta, "SELECT id_jugador FROM jugadores WHERE username = '%s'", usuario);

					pthread_mutex_lock(&mutex);  // Protege el acceso a la BD
					int err = mysql_query(conn, consulta);
					if (!err) {
						MYSQL_RES *res = mysql_store_result(conn);
						if (res != NULL) {
							MYSQL_ROW row = mysql_fetch_row(res);
							if (row != NULL) {
								id_jugador = atoi(row[0]);
							} else {
								fprintf(stderr, "Usuario no encontrado en la base de datos.\n");
							}
							mysql_free_result(res);
						} else {
							fprintf(stderr, "Error al obtener resultado de ID: %s\n", mysql_error(conn));
						}
					} else {
						fprintf(stderr, "Error en la consulta SQL de ID: %s\n", mysql_error(conn));
					}

					// Si se obtuvo el ID del jugador, procesar apuesta
					if (id_jugador != -1) {
						ProcesarApuesta(conn, id_jugador, caballo_apostado, apuesta, respuesta_aux);
						sprintf(respuesta,"7/%s",respuesta_aux);
						send(sock_conn, respuesta, strlen(respuesta), 0);
					} else {
						char error[] = "7/Error al obtener ID del jugador.";
						send(sock_conn, error, strlen(error), 0);
					}

					pthread_mutex_unlock(&mutex);
				} else {
					char error[] = "7/Error al identificar usuario desde socket.";
					send(sock_conn, error, strlen(error), 0);
				}
			}

			else if (codigo == 8) { // Código para invitar a otro usuario
				char usuario_invitado[50];
    			// Continuamos separando la petición como ya lo haces antes
    			p = strtok(NULL, "/");
   			 	if (p != NULL) strcpy(usuario_invitado, p);

				char *usuario_invitador = UsuarioDesdeSocket(&miLista, sock_conn);     // Obtener nombre del que invita desde su socket

				int socket_invitado = -1;
				pthread_mutex_lock(&mutex);
				for (int i = 0; i < miLista.num; i++) {
					if (strcmp(miLista.conectados[i].usuario, usuario_invitado) == 0) {
						socket_invitado = miLista.conectados[i].socket;
						break;
					}
				}
				pthread_mutex_unlock(&mutex);

				if (socket_invitado != -1 && usuario_invitador != NULL) {
			 		// Primero, obtener id_partida del invitador desde la BD y unirlo a al partida
					char consulta[256];
					sprintf(consulta, "SELECT id_partida FROM jugadores WHERE username = '%s'", usuario_invitador);
					err = mysql_query(conn, consulta);
					if (err != 0) {
						printf("Error al consultar la partida del invitador: %u %s\n", mysql_errno(conn), mysql_error(conn));
					} else {
						resultado = mysql_store_result(conn);
						if (resultado != NULL && mysql_num_rows(resultado) > 0) {
							row = mysql_fetch_row(resultado);
							int id_partida = atoi(row[0]);
							// Enviar invitación al usuario invitado
							char mensaje[128];
							sprintf(mensaje, "9/%s/%d\n", usuario_invitador, id_partida); // código 9 = notificación de invitación
							send(socket_invitado, mensaje, strlen(mensaje), 0);

							sprintf(respuesta, "8/Invitación enviada a %s\n", usuario_invitado);

							// Actualizar id_partida del invitado
							sprintf(consulta, "UPDATE jugadores SET id_partida = %d WHERE username = '%s'", id_partida, usuario_invitado);
							err = mysql_query(conn, consulta);
							if (err != 0) {
								printf("Error al asignar partida al invitado: %u %s\n", mysql_errno(conn), mysql_error(conn));
								sprintf(respuesta, "8/No se pudo asignar la partida al invitado\n");
							} else {
								// Notificamos al invitado y al invitador
								sprintf(respuesta, "8/Te has sido unido a la partida de %s\n", usuario_invitador);
								send(socket_invitado, respuesta, strlen(respuesta), 0);

								sprintf(respuesta, "8/El usuario %s se ha unido a tu partida\n", usuario_invitado);
							}
						} else {
							sprintf(respuesta, "8/No se pudo obtener la partida del invitador\n");
						}
					}

				} 
				else {
					sprintf(respuesta, "8/No se pudo invitar al usuario\n");
				}
				send(sock_conn, respuesta, strlen(respuesta), 0);


			}
			else if (codigo == 9) { // Código para responder invitación
				char respuesta_invitacion[10], usuario_invitador[50];
				int id_partida;
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(respuesta_invitacion, p); // "aceptar" o "rechazar"
				p = strtok(NULL, "/");
				if (p != NULL) strcpy(usuario_invitador, p);
				p = strtok(NULL, "/");
				if (p != NULL) id_partida = atoi(p);

				char *usuario_invitado = UsuarioDesdeSocket(&miLista, sock_conn);

				int socket_invitador = -1;
				pthread_mutex_lock(&mutex);
				for (int i = 0; i < miLista.num; i++) {
				if (strcmp(miLista.conectados[i].usuario, usuario_invitador) == 0) {
				socket_invitador = miLista.conectados[i].socket;
				break;
			}
			}
			pthread_mutex_unlock(&mutex);

			if (strcmp(respuesta_invitacion, "aceptar") == 0) {
				char consulta[256];
				sprintf(consulta, "UPDATE jugadores SET id_partida = %d WHERE username = '%s'", id_partida, usuario_invitado);
				err = mysql_query(conn, consulta);
				if (err == 0) {
					sprintf(respuesta, "9/Has aceptado la invitación a la partida %d\n", id_partida);
					send(sock_conn, respuesta, strlen(respuesta), 0);

					if (socket_invitador != -1) {
						sprintf(respuesta, "9/%s ha aceptado tu invitación\n", usuario_invitado);
						send(socket_invitador, respuesta, strlen(respuesta), 0);
					}
				} else {
					sprintf(respuesta, "9/Error al unirte a la partida\n");
					send(sock_conn, respuesta, strlen(respuesta), 0);
				}
			} else { // rechazo
				sprintf(respuesta, "9/Has rechazado la invitación\n");
				send(sock_conn, respuesta, strlen(respuesta), 0);

				if (socket_invitador != -1) {
					sprintf(respuesta, "9/%s ha rechazado tu invitación\n", usuario_invitado);
					send(socket_invitador, respuesta, strlen(respuesta), 0);
					}
			}
		}
<<<<<<< HEAD
=======
		else if (codigo == 10){ //Codigo para el chat
			char usuario[50];
			char mensaje[256];

			p = strtok(NULL, "/"); // usuario
			if (p != NULL) strcpy(usuario, p);

			p = strtok(NULL, "/"); // mensaje
			if (p != NULL) strcpy(mensaje, p);

			char mensajeChat[512];
			sprintf(mensajeChat, "10/%s/%s", usuario, mensaje); // Código 10 es el que maneja el cliente para chat

			pthread_mutex_lock(&mutex);
			for (int i = 0; i < miLista.num; i++) {
				if (miLista.conectados[i].socket != sock_conn) {
					send(miLista.conectados[i].socket, mensajeChat, strlen(mensajeChat), 0);
				}
			}
			pthread_mutex_unlock(&mutex);
		}
		else if (codigo == 11) { // Código para guardar la apuesta
			char usuario[50];
			int caballo_elegido;
			float apuesta;

			p = strtok(NULL, "/"); // usuario
			if (p != NULL) strcpy(usuario, p);

			p = strtok(NULL, "/"); // caballo elegido
			if (p != NULL) caballo_elegido = atoi(p);

			p = strtok(NULL, "/"); // apuesta elegido
			if (p != NULL) apuesta = atof(p);

			snprintf(consulta, sizeof(consulta), 
					"UPDATE jugadores SET caballo_elegido = %d, apuesta = %.2f WHERE username = '%s';", 
					caballo_elegido, apuesta, usuario);

			if (mysql_query(conn, consulta)) {
				printf("Error al actualizar apuesta: %s\n", mysql_error(conn));
			}
		}
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
		else if (codigo == 12) { // Código para jugar con varias personas a la vez
			char usuario[50];
			p = strtok(NULL, "/"); // usuario
			if (p != NULL) strcpy(usuario, p);

<<<<<<< HEAD
			pthread_mutex_lock(&mutex);

			// 1️ Llamar la función una vez para obtener la respuesta
			int caballo_ganador;
   			ProcesarApuestasEnPartida(&miLista, conn, usuario, &caballo_ganador);

    		char respuesta[512];
    		

			// 2️ Obtener el id_partida del jugador
			int id_partida = -1;
			snprintf(consulta, sizeof(consulta),
=======
			char respuesta[512];
			char respuesta_aux[256];

			pthread_mutex_lock(&mutex);

			// 1️ Llamar la función una vez para obtener la respuesta
			ProcesarApuestasEnPartida(conn, usuario, respuesta_aux);
			sprintf(respuesta, "12/%s", respuesta_aux);

			// 2️ Obtener el id_partida del jugador
			int id_partida = -1;
			snprintf(consulta, sizeof(consulta), 
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
					"SELECT id_partida FROM jugadores WHERE username = '%s';", usuario);
			if (mysql_query(conn, consulta) == 0) {
				MYSQL_RES *res = mysql_store_result(conn);
				MYSQL_ROW row = mysql_fetch_row(res);
				if (row != NULL) {
					id_partida = atoi(row[0]);
<<<<<<< HEAD
					miLista.conectados[i].id_partida = id_partida;
					// Actualiza el id_partida en todos los conectados de esa partida
					for (int k = 0; k < miLista.num; k++) {
						if (miLista.conectados[k].estado == 1) {
							// Para este usuario, consultamos la base de datos para obtener su id_partida
							snprintf(consulta, sizeof(consulta), 
									"SELECT id_partida FROM jugadores WHERE username = '%s';", miLista.conectados[k].usuario);
							if (mysql_query(conn, consulta) == 0) {
								MYSQL_RES *res2 = mysql_store_result(conn);
								MYSQL_ROW row2 = mysql_fetch_row(res2);
								if (row2 != NULL) {
									miLista.conectados[k].id_partida = atoi(row2[0]);
								}
								mysql_free_result(res2);
							}
						}
					}
=======
					miLista.conectados[i].id_partida = id_partida; //  Se actualiza el id de la partida
>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
				}
				mysql_free_result(res);
			}

			// 3️ Enviar la respuesta a los jugadores que estén en la misma partida
<<<<<<< HEAD
			for (int k = 0; k < miLista.num; k++) {
				if (miLista.conectados[k].estado == 1 && miLista.conectados[k].id_partida == id_partida) {
					// Obtener puntos del usuario k
					snprintf(consulta, sizeof(consulta), 
							"SELECT puntos FROM jugadores WHERE username = '%s';", 
							miLista.conectados[k].usuario);
					
					if (mysql_query(conn, consulta) == 0) {
						MYSQL_RES *res_puntos = mysql_store_result(conn);
						MYSQL_ROW row_puntos = mysql_fetch_row(res_puntos);
						float puntos_usuario = 0.0;
						if (row_puntos != NULL) {
							puntos_usuario = atof(row_puntos[0]);
						}
						mysql_free_result(res_puntos);

						// Armar mensaje personalizado
						snprintf(respuesta, sizeof(respuesta), "12/%d/%.2f/%s/%.2f", caballo_ganador, puntos_usuario, miLista.conectados[k].resultado_partida, miLista.conectados[k].beneficio_partida);
						// Enviar solo a este usuario
						write(miLista.conectados[k].socket, respuesta, strlen(respuesta));
						printf("Enviando a socket %d con id_partida %d: %s\n", miLista.conectados[k].socket, miLista.conectados[k].id_partida, respuesta);
					}
				}
			}
=======
			if (id_partida != -1) {
				for (int i = 0; i < miLista.num; i++) {
					if (miLista.conectados[i].socket != sock_conn && miLista.conectados[i].id_partida == id_partida) {
						send(miLista.conectados[i].socket, respuesta, strlen(respuesta), 0);
					}
				}
			}

>>>>>>> 9666fcfb15752ff560ceb4e5cd86d592c72f0d51
			pthread_mutex_unlock(&mutex);
		}


			
	}
	mysql_close(conn);
	close(sock_conn);
}
int main(int argc, char *argv[])
{
	miLista.num = 0;
	
	int sock_conn, sock_listen;
	int puerto = 50066; 
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
	// escucharemos en el port 50066
	serv_adr.sin_port = htons(puerto);
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



