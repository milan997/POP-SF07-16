
INSERT INTO tipNamestaja (naziv, obrisan) VALUES ('Krevet', 0);
INSERT INTO tipNamestaja (naziv, obrisan) VALUES ('Ugaona garnitura', 0);
INSERT INTO tipNamestaja (naziv, obrisan) VALUES ('Sofa', 0);

INSERT INTO namestaj (tipNamestajaId, naziv, cena, kolicina, obrisan)
	VALUES (1, 'Francuski krevet', 123.5, 22, 0);
INSERT INTO namestaj (tipNamestajaId, naziv, cena, kolicina, obrisan)
	VALUES (2, 'Sofija ugaona', 223.9, 12, 0);
INSERT INTO namestaj (tipNamestajaId, naziv, cena, kolicina, obrisan)
	VALUES (3, 'Ivan kauc', 723.5, 2, 0);

	




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


