Create Database EFM_M08
use EFM_M08

-- Creation De Table ARTICLE
Go
Create table Article
(Reference_Art int not null Primary key ,Designation_Art varchar(30) , PU_Art varchar(30) ,	QteStock int ,)
	
	

	
-- -- Creation De Table ACHETEUR
Go
create table Acheteur
(Num_Acheteur int not null Primary key ,Nom_Acheteur varchar(30) , Prenom_Acheteur varchar(30) , Type_Acheteur varchar(30) ,MontantTotalVente float  )
	
	
	
-- Creation De Table LIVREUR	
Go
create table Livreur
(Code_Liv int not null Primary key , RaisonSociale_Liv varchar(30) , Adresse_Liv varchar(30) )


-- Creation De Table VENTE	
Go	
create table Vente 
(	Num_Vente int not null primary key , Date_Vente date , Num_Acheteur int ,Paye int , Nombre_Articles int ,Constraint fk_acheteur foreign key (Num_Acheteur) references Acheteur(Num_Acheteur))
	
	
	
	
-- Creation De Table Article_Vendus	
Go
create table Article_Vendus 

	(Num_Vente int , Reference_Art int , Qte_Vendue int ,Constraint pk_art_ven primary key (Num_Vente,Reference_Art),Constraint fk_vente foreign key (Num_Vente) references Vente(Num_Vente) ,	
	Constraint fk_art foreign key (Reference_Art) references Article(Reference_Art))

-- Creation De Table Stock
Go
create table Stock
(
	Num_Entree int identity(1,1) not null Primary key , Date_Entree date , Qte_Entree int ,Reference_Art int ,Code_Liv int ,
	Constraint fk_article foreign key (Reference_Art) references Article(Reference_Art),
	Constraint fk_liv foreign key (Code_Liv) references Livreur(Code_Liv))

--PS1_______________________________________________________
Go
Create Procedure PS1 (@NumV int , @NumA int)
as
begin 
	insert into  Vente(Num_Vente,Date_Vente,Num_Acheteur,Paye) values (@NumV,GETDATE(),@NumA,0) 
end
--PS2_______________________________________________________________
Go
Create Proc PS2(@Numero int)
as 
begin
	if ( Exists ( select * from Vente where Num_Vente = @Numero))
	begin
		print'Valide'
	end
end
--PS3______________________________________________________________
Go
create Proc PS3
as 
begin
	Delete from Acheteur 
	where Num_Acheteur not in( select Num_Acheteur from Vente)
	Delete from Livreur
	where Livreur.Code_Liv not in(select Code_Liv from Stock where Reference_Art not in(select Reference_Art from Article))
end
--PS4__________________________________________________________________
Go
create Proc PS4(@num int)
as
begin
	select MontantTotalVente from Vente,Acheteur 
	where Num_Vente = @num 
	and Vente.Num_Acheteur = Acheteur.Num_Acheteur
end
--PS6___________________________________________________________________
Go
Create Proc PS6(@Numero int,@date1 date , @date2 date)
as 
begin
	select Num_Vente,Date_Vente,MontantTotalVente from Vente ,Acheteur
	where Acheteur.Num_Acheteur = @Numero
	and Date_Vente between @date1 and @date2
end
--PS7_______________________________________________________________________
Go
create Proc PS7
as
begin
	if((select Paye from Vente) != 1 or (select Paye from Vente) != 0)
	begin
		print'Vente Pas encore valider'
	end
end
--PS8_____________________________________________________________________________________
Go
Create Proc PS8
as
begin
	select A.* , Ar.* from Acheteur A , Article Ar , Vente V , Article_Vendus Av
	where A.Num_Acheteur = V.Num_Acheteur
	and Ar.Reference_Art = Av.Reference_Art
	and av.Num_Vente = v.Num_Vente
	group by v.Num_Vente
end



--TR1-----------------------------------------------------------------------------------
Go
create trigger TR1
on Vente for insert
as
begin
		if exists(select * from inserted where paye not in (1,2))
		  rollback transaction
end


--TR2-----------------------------------------------------------------------------------
Go
create trigger TR2
on Article_Vendus for insert
as
begin
		if exists(select Qte_Vendue from inserted where Qte_Vendue<=0)
			rollback transaction

end
--TR3-----------------------------------------------------------------------------------
Go
Create trigger TR3
on Vente for delete
as
begin
		declare @NumVente int,@nbr int

		set @NumVente = (select Num_Vente from deleted)

		if (select count(*) from vente where Num_Vente=@NumVente)=0
		begin
			
			delete Vente where Num_Vente=@NumVente
		end

end

--TR4-----------------------------------------------------------------------------------
Go
create trigger TR4
on Article_Vendus for insert
as
begin
	if(select count(*) from Article_Vendus where Num_Vente = (select Num_Vente from inserted))>5
		rollback transaction
end


--TR5-----------------------------------------------------------------------------------
Go
create trigger TR5
on Article for update
as
begin
		
		update Article set QteStock=QteStock+i.Qte_Entree from inserted i join Article a on a.Reference_Art = i.Reference_Art
		update Article set QteStock=QteStock-d.Qte_Entree from deleted d join Article a on a.Reference_Art = d.Reference_Art

end



--TR6-----------------------------------------------------------------------------------
Go
create trigger TR6
on Vente for delete
as
begin
		declare @Montant float
		select @Montant = isnull(sum(av.Qte_Vendue*a.PU_Art),0) from Vente v join Article_Vendus av on v.Num_Vente= av.Num_Vente join Article a on a.Reference_Art=av.Reference_Art
		where v.Num_Acheteur=(select Num_Acheteur from deleted)
		update Acheteur set MontantTotalVente=@Montant where Num_Acheteur=(select Num_Acheteur from deleted)
end


