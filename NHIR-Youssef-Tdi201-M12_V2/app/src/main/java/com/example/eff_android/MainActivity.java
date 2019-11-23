package com.example.eff_android;

import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Button;
import android.widget.TextView;
import android.widget.ListView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    GestionProduit db=new GestionProduit(this);
    ListView l1 ;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ll=(ListView)findViewById(R.id.lst);
    }
    public void Afficher(View view){

        EditText t1=(EditText)findViewById(R.id.txtPMin);
        EditText t2=(EditText)findViewById(R.id.txtPMax);
        ListView l2=(ListView)findViewById(R.id.lst);
        Button btn=(Button)findViewById(R.id.btnRech);

        ArrayList<Produit> lst = new ArrayList<Produit>();
        lst.addAll(db.Rechercher(Double.parseDouble(t1.getText().toString()),Double.parseDouble(t2.getText().toString())));
        ArrayAdapter<Produit> adp = new ArrayAdapter<Produit>(this,android.R.layout.simple_list_item_1,lst);
        l1.setAdapter(adp);
    }
}
