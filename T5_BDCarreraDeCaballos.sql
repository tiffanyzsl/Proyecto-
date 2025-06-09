DROP DATABASE IF EXISTS T5_BDCarreraDeCaballos;
CREATE DATABASE T5_BDCarreraDeCaballos;
USE T5_BDCarreraDeCaballos;

CREATE TABLE partidas (
    id_partida INT  AUTO_INCREMENT PRIMARY KEY,
    caballo_ganador INT NOT NULL,
    numero_caballos INT NOT NULL DEFAULT 3,
    limite_edad INT,
    duracion INT
)ENGINE = InnoDB;
CREATE TABLE jugadores (
    username VARCHAR(50),
    password_p VARCHAR(50),
    puntos INT,
    edad INT,
    apuesta FLOAT,
    caballo_elegido INT,
    id_jugador INT AUTO_INCREMENT PRIMARY KEY,
    id_partida INT,
    FOREIGN KEY (id_partida) REFERENCES partidas(id_partida)
)ENGINE = InnoDB;
CREATE TABLE historial (
    partidas_jugadas INT,
    partidas_ganadas INT,
    beneficio_total FLOAT ,
    id_jugador INT NOT NULL,
    FOREIGN KEY (id_jugador) REFERENCES jugadores(id_jugador)
)ENGINE = InnoDB;
DELIMITER $$

CREATE TRIGGER generar_campos_aleatorios_partidas
BEFORE INSERT ON partidas
FOR EACH ROW
BEGIN
    DECLARE max_caballos INT;
    SET max_caballos = NEW.numero_caballos;

    -- Asignar caballo_ganador aleatorio entre 1 y max_caballos
    SET NEW.caballo_ganador = FLOOR(1 + (RAND() * max_caballos));

    -- Número aleatorio para duración entre 60 y 180 segundos
    SET NEW.duracion = FLOOR(60 + (RAND() * 121));
END$$

DELIMITER ;

INSERT INTO jugadores (username, password_p, puntos, edad) VALUES
('kiko', 'klk', 500, 17),
('lola', 'lol', 1000, 20);

INSERT INTO partidas (numero_caballos, limite_edad) VALUES (3, 18);
INSERT INTO partidas (numero_caballos, limite_edad) VALUES (3, 21);
INSERT INTO partidas (numero_caballos, limite_edad) VALUES (3, 16);



