CREATE TABLE tipNamestaja (
	id INT PRIMARY KEY IDENTITY(1, 1),
	naziv VARCHAR(80),
	obrisan BIT		
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