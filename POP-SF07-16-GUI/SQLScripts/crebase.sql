CREATE TABLE tipNamestaja (
	id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	naziv VARCHAR(80) NOT NULL,
	obrisan BIT	DEFAULT 0 NOT NULL	
	);

CREATE TABLE namestaj(
	id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	naziv VARCHAR(69) NOT NULL,
	sifra VARCHAR(69) NOT NULL,
	cena DECIMAL(9, 2) NOT NULL,
	kolicina INT NOT NULL,
	tipNamestaja_id INT FOREIGN KEY REFERENCES tipNamestaja(id),
	akcija_id INT FOREIGN KEY REFERENCES akcija(id),
	obrisan BIT DEFAULT 0
	);

CREATE TABLE akcija(
	id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	naziv VARCHAR(69) NOT NULL,
	datumPocetka DATE NOT NULL,
	datumZavrsetka DATE NOT NULL,
	popust NUMERIC(9, 0) NOT NULL,
	obrisan BIT DEFAULT 0 NOT NULL
	);

CREATE TABLE dodatnaUsluga (
	id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	naziv VARCHAR(69) NOT NULL,
	cena DECIMAL (9, 2) NOT NULL,
	obrisan BIT DEFAULT 0 NOT NULL
	);

CREATE TABLE korisnik(
	id INT PRIMARY KEY IDENTITY(1, 1)NOT NULL ,
	ime VARCHAR(69) NOT NULL,
	prezime VARCHAR(69) NOT NULL,
	korIme VARCHAR(69) UNIQUE NOT NULL,
	lozinka VARCHAR(69) NOT NULL,
	tipKorisnika BIT DEFAULT 0 NOT NULL,
	obrisan BIT DEFAULT 0 NOT NULL
);

CREATE TABLE salon(
	id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	naziv VARCHAR(69) NOT NULL,
	adresa VARCHAR(69) NOT NULL,
	telefon VARCHAR(69),
	email VARCHAR(69),
	webAdresa VARCHAR(69),
	pib VARCHAR(69),
	maticniBroj VARCHAR(69),
	brRacuna VARCHAR(69),
	obrisan BIT DEFAULT 0 NOT NULL
	);

CREATE TABLE prodaja(
	id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	datumProdaje DATETIME NOT NULL,
	brRacuna VARCHAR(69) NOT NULL,
	kupac VARCHAR(69) NOT NULL
	);

CREATE TABLE collection_kupljeniNamestaj(
	prodaja_id INT FOREIGN KEY REFERENCES prodaja(id) NOT NULL ,
	namestaj_id INT FOREIGN KEY REFERENCES namestaj(id) NOT NULL ,
	kolicina INT NOT NULL,
	obrisan BIT DEFAULT 0
	PRIMARY KEY(prodaja_id, namestaj_id)
	); 
	
CREATE TABLE collection_kupljenaDodatnaUsluga(
	prodaja_id INT FOREIGN KEY REFERENCES prodaja(id) NOT NULL ,
	dodatnaUsluga_id INT FOREIGN KEY REFERENCES dodatnaUsluga(id) NOT NULL,
	kolicina INT NOT NULL,
	obrisan BIT DEFAULT 0
	PRIMARY KEY (prodaja_id, dodatnaUsluga_id)
	);



