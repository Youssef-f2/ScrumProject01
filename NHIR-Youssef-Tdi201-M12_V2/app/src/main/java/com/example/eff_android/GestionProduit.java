package com.example.eff_android;
import  android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import  android.database.sqlite.SQLiteOpenHelper;
import  android.content.ContentValues;
import  java.util.ArrayList;
import  android.database.Cursor;
public class GestionProduit extends SQLiteOpenHelper{
    public final static String Nom_Bas="data.db";
    public final static int LaVerssion=1;
    public  GestionProduit(Context context)
    {
        super(context,Nom_Bas,null,LaVerssion);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE Produit( nun integer ,reference integer,designation TEXT,prix float,quantite integer)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS Produit");
        onCreate(db);
    }
    public  boolean AjouterProduit(int nun,int reference,String designation,float prix,int quantite)
    {
        SQLiteDatabase database=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("nun",nun);
        contentValues.put("reference",reference);
        contentValues.put("designation",designation);
        contentValues.put("prix",prix);
        contentValues.put("quantite",quantite);

        long result=database.insert("Contact",null,contentValues);

        if(result==1){
            return false;
        }
        else
            return true;


    }
    public  boolean SuppimerProduit(int reference)
    {
        SQLiteDatabase database=this.getWritableDatabase();
        ContentValues contentValues=new ContentValues();
        contentValues.put("reference",reference);

        long result=database.delete("Produit","reference="+reference,null);

        if(result==1){
            return true;
        }
        else
            return false;


    }



    public ArrayList<String> AfficherTous(){
        ArrayList<String> L=new ArrayList<String>();
        SQLiteDatabase database=this.getReadableDatabase();
        Cursor cursor=database.rawQuery("SELECT *FROM Contact",null);

        if(cursor.moveToFirst()){
            do{

                String container=cursor.getInt(0)+"-"+cursor.getString(1)+"-"+cursor.getString(2)+"-"+cursor.getString(3)+"-"+cursor.getString(4);

                L.add(container);

            }while (cursor.moveToNext());

        }

        return  L;
    }




    public ArrayList<String> Rechercher(Double MAX,Double MIN){
        ArrayList<String> List = new ArrayList<String>();
        SQLiteDatabase db=this.getReadableDatabase();
        String[] colonnesARecup = new String[] { "nun","designation", "prix","quantite" };

        Cursor cursorResults = db.query("Produit", colonnesARecup,"prix > "+MAX+" and prix < "+MIN ,
                null, null, null, null, null);
        if (null != cursorResults) {
            if (cursorResults.moveToFirst()) {
                do {
                    int IndexNum = cursorResults.getColumnIndex("nun");
                    int IndexDes = cursorResults.getColumnIndex("designation");
                    int IndexPrix=cursorResults.getColumnIndex("prix");
                    int IndexQte=cursorResults.getColumnIndex("quantite");

                    String Aff =cursorResults.getString(IndexNum)
                            + "-" + cursorResults.getString(IndexDes)
                            + " " + cursorResults.getString(IndexPrix)
                            + " " + cursorResults.getString(IndexQte);

                    List.add(Aff);
                } while (cursorResults.moveToNext());
            }
        }
        return List;

    }

}
