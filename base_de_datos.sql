DROP DATABASE IF EXISTS carrera_caballos;
CREATE DATABASE carrera_caballos;
USE carrera_caballos;

CREATE TABLE partidas (
    id_partida INT  AUTO_INCREMENT PRIMARY KEY,
    fecha DATE ,
    limite_edad INT ,
    duracion FLOAT 
)ENGINE = InnoDB;
CREATE TABLE jugadores (
    username VARCHAR(50),
    password_p VARCHAR(50),
    nombre VARCHAR(50) ,
    edad INT ,
    id_jugador INT AUTO_INCREMENT PRIMARY KEY,
    id_partida INT DEFAULT NULL,
    FOREIGN KEY (id_partida) REFERENCES partidas(id_partida)
)ENGINE = InnoDB;
CREATE TABLE historial (
	partidas_jugadas INT ,
	partidas_ganadas INT,
	beneficio_total FLOAT ,
	id_jugador INT PRIMARY KEY ,
	FOREIGN KEY (id_jugador) REFERENCES jugadores(id_jugador)
)ENGINE = InnoDB;
INSERT INTO partidas ( fecha, limite_edad, duracion) VALUES
( '2025-03-02', 18, 12),
( '2025-03-04', 16, 10),
('2025-03-07', 17, 20),
('2025-03-10', 21, 15);
INSERT INTO jugadores (username, password_p, nombre, edad) VALUES
( 'JuanP', 'juans', 'Juan', 5),
('Laurita', 'lc', 'Laura', 20 );

INSERT INTO historial (partidas_jugadas, partidas_ganadas, beneficio_total, id_jugador) VALUES
(2, 1, 50, 1),
(10,5,100, 2);


