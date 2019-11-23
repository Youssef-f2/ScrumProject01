package com.example.eff_android;

public class Produit {

    public int numero ;
    public  int reference;
    public String designation ;
    public Float prix;
    public  int quantite;

    @Override
    public String toString() {
        return "Produit{" +
                "numero=" + numero +
                ", reference=" + reference +
                ", designation='" + designation + '\'' +
                ", prix=" + prix +
                ", quantite=" + quantite +
                '}';
    }



    public void setNumero(int numero) {
        this.numero = numero;
    }

    public void setReference(int reference) {
        this.reference = reference;
    }

    public void setDesignation(String designation) {
        this.designation = designation;
    }

    public void setPrix(Float prix) {
        this.prix = prix;
    }

    public void setQuantite(int quantite) {
        this.quantite = quantite;
    }




    public int getNumero() {
        return numero;
    }

    public int getReference() {
        return reference;
    }

    public String getDesignation() {
        return designation;
    }

    public Float getPrix() {
        return prix;
    }

    public int getQuantite() {
        return quantite;
    }

    public Produit(){};

    public Produit(int numero, int reference, String designation, Float prix, int quantite) {
        this.numero = numero;
        this.reference = reference;
        this.designation = designation;
        this.prix = prix;
        this.quantite = quantite;
    }


}
