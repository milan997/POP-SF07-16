--tipNamestaja
INSERT INTO tipNamestaja (naziv) 
	VALUES ('Krevet');
INSERT INTO tipNamestaja (naziv) 
	VALUES ('Ugaona garnitura',);
INSERT INTO tipNamestaja (naziv) 
	VALUES ('Sofa');

--namestaj
INSERT INTO namestaj (tipNamestajaId, naziv, cena, kolicina)
	VALUES (1, 'Francuski krevet', 123.5, 22);
INSERT INTO namestaj (tipNamestajaId, naziv, cena, kolicina)
	VALUES (2, 'Sofija ugaona', 223.9, 12);
INSERT INTO namestaj (tipNamestajaId, naziv, cena, kolicina)
	VALUES (3, 'Ivan kauc', 723.5, 2,);

--akcija
INSERT INTO akcija (naziv, datumPocetka, datumZavrsetka, popust)
	VALUES('Novogodisnja Akcija', '2017-12-31', '2018-01-02', 10);	
INSERT INTO akcija (naziv, datumPocetka, datumZavrsetka, popust)
	VALUES('Uskrsnji popust', '2018-01-05', '2018-01-08', 20);
INSERT INTO akcija (naziv, datumPocetka, datumZavrsetka, popust)
	VALUES('Prolecne patike', '2018-03-01', '2018-05-30', 5);

--dodatna usluga
INSERT INTO dodatnaUsluga (naziv, cena)
	VALUES ('Prevoz', 420);
INSERT INTO dodatnaUsluga (naziv, cena)
	VALUES ('Pakovanje', 200);
INSERT INTO dodatnaUsluga (naziv, cena)
	VALUES ('Ulaz', 800);

--korisnik
INSERT INTO korisnik (ime, prezime, korIme, lozinka, tipKorisnika)
	VALUES ('Milan', 'Miljus', 'milan997', '123', 1);
INSERT INTO korisnik (ime, prezime, korIme, lozinka, tipKorisnika)
	VALUES ('Jovan', 'Jovanovic', 'jovo123', '123', 0);
INSERT INTO korisnik (ime, prezime, korIme, lozinka, tipKorisnika)
	VALUES ('Marko', 'Markovic', 'marko123', '123', 0);

--salon
INSERT INTO salon (naziv, adresa, telefon, email, webAdresa, pib, maticniBroj, brRacuna)
	VALUES ('Salon1', 'Zeleni Venac 420', '021-555-222', 'salon@salon1.com', 'www.salon1.com', '123', '420', '168-12312312-99');

--namestaj
INSERT INTO namestaj (naziv, sifra, cena, kolicina, tipNamestaja_id, akcija_id)
	VALUES ('Krevet', 'SF123', 25000, 20, 1, 1);
INSERT INTO namestaj (naziv, sifra, cena, kolicina, tipNamestaja_id, akcija_id)
	VALUES ('Kauc', 'SF333', 8000, 60, 3, 2);
INSERT INTO namestaj (naziv, sifra, cena, kolicina, tipNamestaja_id, akcija_id)
	VALUES ('Ugaono oko stola', 'SF676', 44000, 2, 2, 3);


/* 
	VRACA CONNECTION STRING

	select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name()
    end
from sys.server_principals
where name = suser_name()

*/


