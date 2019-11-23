package com.example.tp_jeu;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.support.v7.app.AlertDialog;
import android.widget.TextView;
import android.text.util.*;
import android.widget.Toast;

import java.util.Random;


public class MainActivity extends AppCompatActivity {

    Button btnComparer;
    EditText txtNum;
    TextView lblTentative;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnComparer=(Button)findViewById(R.id.btnComparer);
        txtNum=(EditText)findViewById(R.id.txtNbr);
        lblTentative=(TextView) findViewById(R.id.lblTentative);

        btnComparer.setOnClickListener(new View.OnClickListener()
        {
            Random rn = new Random();
            int nbr = rn.nextInt(100) + 1;
            int x=0;

            @Override
            public void onClick(View v)
            {
                if(!(txtNum.getText().toString().equals("")))
                {
                    int i=Integer.parseInt(txtNum.getText().toString());
                    if(i==nbr)
                    {
                        lblTentative.setText("Victoire Apres"+x+"Fois");
                    }
                    else
                    if (i > nbr)
                    {
                        lblTentative.setText("Veuillez Saisir Un nombre plus petit");
                        x++;
                    }
                    else

                    if(i < nbr)
                    {
                        lblTentative.setText("Veuillez Saisir Un nombre plus grand");
                        x++;
                    }
                }
                else
                {
                    Toast.makeText(getApplicationContext(),"Veuillez Saisir Un Nombre",Toast.LENGTH_SHORT).show();
                }
            }
        });
    }
}
