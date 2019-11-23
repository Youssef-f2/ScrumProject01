create database LocationDesVoitures
use LocationDesVoitures
create table Voitures(IdVoiture as 'V-' + RIGHT(REPLICATE ('0','1') + Convert(varchar, CMP), 10) PERSISTED not null Primary key ,CMP int Identity(1,1),Marque varchar(100) ,Matricule varchar(20),Capacite varchar(20) , Boite_Vitesse varchar(30) ,Carburant varchar(30),Couleur Varchar(30), Disponibilite varchar(10) , Prix_Par_Jour Varchar(20))

insert into Voitures values ('RENAULT CLIO 4','78864|B|2' ,'5 Places','Automatique','Diesel','Rouge','Oui','250 DH')
insert into Voitures values ('FORD FOCUS ','2172|M|17' ,'5 Places','Manuelle','Essence','Bleu','Oui','300 DH')
insert into Voitures values ('DACIA SANDERO','9432|S|92' ,'4 Places','Manuelle','Diesel','Noir','Oui','200 DH')
insert into Voitures values ('HYUNDI I10','234|W|65' ,'4 Places','Automatique','Diesel','Noir','Oui','180 DH')
insert into Voitures values ('DACIA LOGAN','8532|Y|3' ,'5 Places','Automatique','Essence','Blanc','Oui','200 DH')
insert into Voitures values ('MERCEDECE CLASS A','8634|I|78' ,'5 Places','Automatique','Diesel','Gris','Oui','500 DH')
insert into Voitures values ('RANG ROVER EVOQUE ','4567|V|7' ,'6 Places','Automaique','Essence','Bleu Marine','Oui','700 DH')
insert into Voitures values ('SKODA OCTAVIA','462|J|34' ,'5 Places','Manuelle','Diesel','Noir','Oui','300 DH')
insert into Voitures values ('HYUNDI I30','24534|Z|6' ,'4 Places','Automatique','Diesel','Rouge','Oui','200 DH')
insert into Voitures values ('VOLSWAGEN TOUAREG','9834|X|9' ,'6 Places','Manuelle','Essence','Blanc','Oui','400 DH')

create table Locateurs (IdLocateur  as 'L-' + RIGHT(REPLICATE ('0','1') + Convert(varchar, CMP), 10) PERSISTED not null Primary key  ,CMP int Identity(1,1),CIN varchar(20) , NomComplete varchar(50) , DateDeNaissance date , Telephone varchar(20) ,Adresse text )
insert into Locateurs values ('BJ451862','RAWI Ismail','12/12/1998','0643019302','Hay Mohemmadi')

create table Locations (IdLocation as 'LOC-' + RIGHT(REPLICATE ('0','1') + Convert(varchar, CMP), 10) PERSISTED not null ,CMP int Identity(1,1),IdVoiture Varchar(12) not null  , IdLocateur Varchar(12) not null, Marque varchar(50) , NomLocateur Varchar(50),  DateLocation date , DateSoumission date , NombreDeJour varchar(20) , PrixTotal Varchar(20) )
alter table Locations add constraint PK_Location primary key (IdLocation,IdVoiture,IdLocateur)
alter table Locations add constraint FK1_Location foreign key (IdVoiture) References Voitures(IdVoiture) On delete cascade
alter table Locations add constraint FK2_Location foreign key (IdLocateur) References Locateurs(IdLocateur) On delete cascade
 
create table Identification (Identifiant varchar(50) not null primary key ,Nom varchar(20) , Prenom Varchar(20) , MotDePasse varchar(30), Privilege varchar(20), Email varchar(50), QuestionDeSecurite varchar(100) , Reponse varchar(100))
insert into Identification values ('Mouad','NID TALEB','Mouad','Mouad123','Admin','mouadnidtaleb@gmail.com','Quelle est ton film prefere?','the porsuit of happiness')
insert into Identification values ('Oussama','NID TALEB','Oussama','Oussama123','Utilisateur','oussamanidtaleb@gmail.com','Quelle est ton amie prefere?','mouad')
delete  from Voitures
create trigger UpdateVoiture ON Voitures After Update
As 
declare @a varchar(30)
declare @b varchar(30)
Set @a = (Select IdVoiture from inserted)
Set @b = (Select Marque from inserted)
if exists ( Select * from Locations where IdVoiture = @a) 
begin
Update Locations set Marque = @b where IdVoiture = @a
end


Create trigger UpdateLocateur ON Locateurs After Update
As 
declare @a varchar(30)
declare @b varchar(50)
Set @a = (Select IdLocateur from inserted)
Set @b = (Select NomComplete from inserted)
if exists ( Select * from Locations where IdLocateur = @a) 
begin
Update Locations set NomLocateur = @b where IdLocateur = @a
end




create view LastLocation
AS

(select TOP 1 * from Locations order by IdLocation desc)

create view LastLocationVoiture
AS

Select * from Voitures where IdVoiture = (select TOP 1 IdVoiture from Locations order by IdLocation desc )


create view LastLocationLocateur
AS

Select * from Locateurs where IdLocateur = (select TOP 1 IdLocateur from Locations order by IdLocation desc )


alter proc ImpLoca ( @i varchar(50) )
as
begin 
declare  @a varchar(50) ;
set @a = (Select IdLocateur from Locations where IdLocation = @i)
declare  @b varchar(50) ;
set @b = (Select IdVoiture from Locations where IdLocation = @i)
Select * from Locations L , Voitures V , Locateurs Lo where l.IdLocation = @i and V.IdVoiture=@b and LO.IdLocateur = @a
END


create proc ImpVoitureDispo 
as 
begin 
select * from Voitures where Disponibilite = 'Oui'
end

create proc ImpVoitureInDispo 
as 
begin 
select * from Voitures where Disponibilite = 'Non'
end


alter proc ImpLocateurForLocation(@i varchar(50)) 
as 
begin 
select * from Locations where IdLocateur = @i order by DateLocation
end


alter proc ImpVoitureForLocation(@i varchar(50)) 
as 
begin 
select * from Locations where IdVoiture = @i order by DateLocation
end


create view ListeVoitures
AS

Select * from Voitures 

create view ListeLocateurs
AS

Select * from Locateurs 


create proc ImpParDateLocation ( @d date )
as 
begin 
select * from Locations where DateLocation = @d
end

create proc ImpEntreDeuxDateLocation ( @d date , @d2 date )
as 
begin 
select * from Locations where DateLocation between @d and @d2
end



Select * from Locations

