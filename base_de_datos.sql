DROP DATABASE IF EXISTS carrera_caballos;
CREATE DATABASE carrera_caballos;
USE carrera_caballos;

CREATE TABLE partidas (
    id_partida INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATE NOT NULL,
    limite_edad INT NOT NULL,
    duracion INT NOT NULL
)ENGINE = InnoDB;
CREATE TABLE jugadores (
    id_jugador INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    username VARCHAR(50) NOT NULL,
    password_p VARCHAR(50) NOT NULL,
    edad INT NOT NULL,
    id_partida INT DEFAULT NULL,
    FOREIGN KEY (id_partida) REFERENCES partidas(id_partida)
)ENGINE = InnoDB;
CREATE TABLE historial (
	partidas_jugadas INT NOT NULL,
	partidas_ganadas INT NOT NULL,
	beneficio_total DECIMAL(10,2) NOT NULL,
	id_jugador INT NOT NULL,
	FOREIGN KEY (id_jugador) REFERENCES jugadores(id_jugador)
)ENGINE = InnoDB;
INSERT INTO partidas (fecha, limite_edad, duracion) VALUES
('2025-03-02', 18, 12),
('2025-03-04', 16, 10),
('2025-03-07', 17, 20),
('2025-03-10', 21, 15);
INSERT INTO jugadores (nombre, username, password_p, edad) VALUES
('Juan', 'JuanP', 'juans',5),
('Laura', 'Laurita', 'lc',20);
