INSERT INTO tbe.tUser(Passe,FirstName,LastName,City,Tel,Mail,Pro,Siret,Compagny) VALUES('vivi','victor','andre','Paris','0087810','victor.andre@gmail.com',0,null,null);
INSERT INTO tbe.tUser(Passe,FirstName,LastName,City,Tel,Mail,Pro,Siret,Compagny) VALUES('vivi','you','tu','Paris','00810','je@gmail.com',1,00976898,'la');
INSERT INTO tbe.tUser(Passe,FirstName,LastName,City,Tel,Mail,Pro,Siret,Compagny) VALUES('vivi','fuck','Baise','Paris','000180','te@gmail.com',1,00976898,'Tvie');
INSERT INTO tbe.tUser(Passe,FirstName,LastName,City,Tel,Mail,Pro,Siret,Compagny) VALUES('vivi','The','le','Paris','00018','fait@gmail.com',1,00976898,'en');
INSERT INTO tbe.tUser(Passe,FirstName,LastName,City,Tel,Mail,Pro,Siret,Compagny) VALUES('vivi','World','Monde','Paris','018810','ce@gmail.com',1,00976898,'rose');
INSERT INTO tbe.tUser(Passe,FirstName,LastName,City,Tel,Mail,Pro,Siret,Compagny) VALUES('vivi','lala','lili','Paris','00018810','titir@gmail.com',0,null,null);
INSERT INTO tbe.tUser(Passe,FirstName,LastName,City,Tel,Mail,Pro,Siret,Compagny) VALUES('vivi','jame','harden','Paris','06618810','hardr@gmail.com',0,null,null);
INSERT INTO tbe.tUser(Passe,FirstName,LastName,City,Tel,Mail,Pro,Siret,Compagny) VALUES('vivi','Michael','Jordan','Chicago','9990','Jordan@gmail.com',0,null,null);

INSERT INTO tbe.tTraiteur(UserId) VALUES(1);
INSERT INTO tbe.tTraiteur(UserId) VALUES(2);
INSERT INTO tbe.tTraiteur(UserId) VALUES(3);
INSERT INTO tbe.tTraiteur(UserId) VALUES(4);

INSERT INTO tbe.tMenu(Nom,Cat,Prix,NbPersonnes,TraiteurId) VALUES('Mariage','Plat',21,40,1);
INSERT INTO tbe.tMenu(Nom,Cat,Prix,NbPersonnes,TraiteurId) VALUES('Anniv','Dessert',18,20,2);
INSERT INTO tbe.tMenu(Nom,Cat,Prix,NbPersonnes,TraiteurId) VALUES('Reception','Plat',40,100,3);
INSERT INTO tbe.tMenu(Nom,Cat,Prix,NbPersonnes,TraiteurId) VALUES('Barmitva','Entrer',100,10,4);
INSERT INTO tbe.tMenu(Nom,Cat,Prix,NbPersonnes,TraiteurId) VALUES('Soiree','Plat',10,70,4);

INSERT INTO tbe.tDeco(UserId) VALUES(1);
INSERT INTO tbe.tDeco(UserId) VALUES(2);
INSERT INTO tbe.tDeco(UserId) VALUES(3);
INSERT INTO tbe.tDeco(UserId) VALUES(4);
INSERT INTO tbe.tDeco(UserId) VALUES(4);

INSERT INTO tbe.Salle(Nbplace,UserId) VALUES(100,1);
INSERT INTO tbe.Salle(Nbplace,UserId) VALUES(200,2);
INSERT INTO tbe.Salle(Nbplace,UserId) VALUES(300,3);
INSERT INTO tbe.Salle(Nbplace,UserId) VALUES(400,4);
INSERT INTO tbe.Salle(Nbplace,UserId) VALUES(500,3);

INSERT INTO tbe.tEvent(NomEvent,NbInvite,Prix,MenuId,SalleId,TraiteurId,DecoId,Localisation,UserId) VALUES('Les bourer','60',1000,1,1,1,1,'Paris',0);
INSERT INTO tbe.tEvent(NomEvent,NbInvite,Prix,MenuId,SalleId,TraiteurId,DecoId,Localisation,UserId) VALUES('The One','250',1000,2,2,2,2,'Paris',6);
INSERT INTO tbe.tEvent(NomEvent,NbInvite,Prix,MenuId,SalleId,TraiteurId,DecoId,Localisation,UserId) VALUES('Les Enfoirer','300000',1000,2,3,3,3,'Paris',7);
INSERT INTO tbe.tEvent(NomEvent,NbInvite,Prix,MenuId,SalleId,TraiteurId,DecoId,Localisation,UserId) VALUES('Sodomi du matin repo sdu vagin','4000',1000,2,3,0,1,'Marseille',8);

INSERT INTO tbe.tMessage(UserId1,UserId2,Text) VALUES(0,3,'Bonjour');
INSERT INTO tbe.tMessage(UserId1,UserId2,Text) VALUES(0,2,'Bonjour');
INSERT INTO tbe.tMessage(UserId1,UserId2,Text) VALUES(0,3,'Bonjour');
INSERT INTO tbe.tMessage(UserId1,UserId2,Text) VALUES(3,0,'Nope');

