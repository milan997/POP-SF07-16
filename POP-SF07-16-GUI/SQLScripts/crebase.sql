CREATE TABLE tipNamestaja (
	id INT PRIMARY KEY IDENTITY(1, 1),
	naziv VARCHAR(80),
	obrisan BIT	DEFAULT 0	
	);

CREATE TABLE namestaj(
	id INT PRIMARY KEY IDENTITY(1, 1),
	tipNamestajaId INT,
	akcijaId INT,
	naziv VARCHAR(100),
	cena NUMERIC(9, 2),
	kolicina INT,
	obrisan BIT,
	FOREIGN KEY(tipNamestajaId) REFERENCES tipNamestaja(id)
	); 

CREATE TABLE akcija(
	id INT PRIMARY KEY IDENTITY(1, 1),
	naziv VARCHAR(69),
	datumPocetka DATE,
	datumZavrsetka DATE,
	popust NUMERIC(9, 0),
	obrisan BIT DEFAULT 0
	);

CREATE TABLE dodatnaUsluga (
	id INT PRIMARY KEY IDENTITY(1, 1),
	naziv VARCHAR(69),
	cena DECIMAL (9, 2),
	obrisan BIT DEFAULT 0
	);

CREATE TABLE korisnik(
	id INT PRIMARY KEY IDENTITY(1, 1),
	ime VARCHAR(69),
	prezime VARCHAR(69),
	korIme VARCHAR(69) UNIQUE,
	lozinka VARCHAR(69),
	tipKorisnika BIT DEFAULT 0,
	obrisan BIT DEFAULT 0
);

CREATE TABLE salon(
	id INT PRIMARY KEY IDENTITY(1, 1),
	naziv VARCHAR(69),
	adresa VARCHAR(69),
	telefon VARCHAR(69),
	email VARCHAR(69),
	webAdresa VARCHAR(69),
	pib VARCHAR(69),
	maticniBroj VARCHAR(69),
	brRacuna VARCHAR(69),
	obrisan BIT DEFAULT 0
	);

CREATE TABLE namestaj(
	id INT PRIMARY KEY IDENTITY(1, 1),
	naziv VARCHAR(69),
	sifra VARCHAR(69),
	cena DECIMAL(9, 2),
	kolicina INT,
	tipNamestaja_id INT FOREIGN KEY REFERENCES tipNamestaja(id),
	akcija_id INT FOREIGN KEY REFERENCES akcija(id),
	obrisan BIT DEFAULT 0
	);



