using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.Data.OleDb;
using gamon.ForeignWords;
using System.Collections;
using System.Windows.Forms;

namespace gamon.ForeignWords
{
    /// <summary>
    /// Data Access Layer che astrae l'accesso ai dati attraverso il dbms
    /// </summary>
    public class libDBForeignWords
    {
        //string nomeDatabase = "parole";
        string nomeDatabase = "dbForeignWords";

        TipoDB tipoDB;
        public enum TipoDB {
            Access,
            MySQL,
            MSSQL,
            SQLite,
            Testo
        }
        #region costruttori
        public libDBForeignWords(TipoDB tipoDB)
        {
             this.tipoDB = tipoDB;
        }
        #endregion

        #region funzioni che prendono un campo di database e lo mettono nella destinazione senza inchiodarsi

        public string GetSafeString(DbDataReader r, int nCampo)
        {
            try
            {
                return r.GetString(nCampo);
            }
            catch
            {
                return "";
            }
        }

        public string GetSafeString(object Campo)
        {
            try
            {
                return Campo.ToString();
            }
            catch
            {
                return "";
            }
        }

        public long GetSafeInt(DbDataReader r, int nCampo)
        {
            try
            {
                return Convert.ToInt64(r.GetValue(nCampo).ToString().Trim());
            }
            catch
            {
                return 0;
            }
        }

        public double SafeDouble(string d)
        {
            try
            {
                return Convert.ToDouble(d);
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region funzioni che preparano una grandezza per essere usata in statement SQL
        public string dataDB(string data)
        {
            switch (tipoDB)
            {
                case TipoDB.Access:
                    {
                        return ("#" + Convert.ToDateTime(data).ToString("yyyy-MM-dd") + "#");
                    }
                case TipoDB.MySQL:
                    {
                        return "";
                    }
                case TipoDB.MSSQL:
                    {
                        return "";
                    }
                default:
                    return "";
            }
        }

        public string dataOraDB(string data)
        {
            try
            {
                switch (tipoDB)
                {
                    case TipoDB.Access:
                        {
                            // TODO ATTENZIONE: converte 13:29 in 1:29 !!!!
                            return ("#" + Convert.ToDateTime(data).ToString("yyyy-MM-dd hh:mm:ss") + "#");
                        }
                    case TipoDB.MySQL:
                        {
                            return "";
                        }
                    case TipoDB.MSSQL:
                        {
                            return "";
                        }
                    default:
                        {
                            return "";
                        }
                }
            }
            catch
            {
                return "null";
            }
        }

        public string stringDB(string stringa)
        {
            // TODO verificare ed aggiustare
            string temp = stringa;

            temp = temp.Replace(@"""", @"""""");
            temp = temp.Replace("'", "''");
            temp = "'" + temp + "'";

            return temp;
        }

        public string floatDB(string numero)
        {
            try
            {
                return numero.Replace(",", ".");
            }
            catch
            {
                return "null";
            }
        }

        public string intDB(string numero)
        {
            try
            {
                return numero.ToString();
            }
            catch
            {
                return "null";
            }
        }
        #endregion

        #region funzioni generali per i database
        public int nCampoDbDataReader(string NomeCampo, DbDataReader dr)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i) == NomeCampo)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region Metodi specifici per questo programma
        public DbConnection Connetti()
        {
            //gamonLib.Qui("Inizio metodo Connetti per database "  + database );
            DbConnection conn;
            try
            {
                switch (tipoDB)
                {
                    case TipoDB.SQLite:
                        {
                            //string pathDati = Application.LocalUserAppDataPath;
                            // toglie la versione dalla path e va nella cartella di ForeginWords
                            //pathDati = pathDati.Substring(0, pathDati.LastIndexOf('\\'));
                            //pathDati = pathDati.Substring(0, pathDati.LastIndexOf('\\'));
                            //pathDati += "\\ForeignWords\\";
                            string pathDati = ".\\";
                            conn = new SQLiteConnection("Data Source=" + pathDati + nomeDatabase + ".sqlite");
                            break;
                        }
                    case TipoDB.Access:
                        {
                            conn = new System.Data.OleDb.OleDbConnection(
                                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + nomeDatabase + ".accdb");
                           break;
                        }

                    default:
                        {
                            conn = null;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error connecting to the server: " + ex.Message + "\r\n" + "Database " + database);
                Console.WriteLine("Error connecting to the server: " + ex.Message + "\r\n");
                conn = null;

                //gamonLib.Qui("Errore in connessione a " + database);
            }
            //gamonLib.Qui("Fine metodo Connetti()");
            conn.Open();
            return conn;
        }
        //dAdapter = new SQLiteDataAdapter("SELECT * FROM VerbiInglesi;",
        //                                    (System.Data.SQLite.SQLiteConnection)conn);

        public void DataSetVerbi(int CodEsercizio, ref DbDataAdapter dAdapter, ref DataSet dSet)
        {
            DbConnection conn = Connetti();
            string query = "SELECT IdVerb, Infinitive, PastParticiple, PastTense"; 
            if (Global.LinguaCorrente != "English")
                query += ", Inf" + Global.LinguaCorrente;
            query += " FROM VerbiInglesi, VerbiEsercizi" + 
            " WHERE (VerbiInglesi.IdVerb = VerbiEsercizi.IdVerbo AND VerbiEsercizi.IdEsercizio=" +
            CodEsercizio + ")" +
            "ORDER BY Infinitive;";
            switch (tipoDB)
            {
                case TipoDB.SQLite:
                    {
                        dAdapter = new SQLiteDataAdapter(query ,(System.Data.SQLite.SQLiteConnection)conn);
                        break;
                    }
                case TipoDB.Access:
                    {
                        dAdapter = new System.Data.OleDb.OleDbDataAdapter(query,
                                (System.Data.OleDb.OleDbConnection)conn);
                        break;
                    }
                default:
                    {
                        conn = null;
                        break;
                    }
            }

            // generazione delle query per le modifiche. E' stata commentata perchè il dataset ora serve
            // solo per popolare le tabelle, la modifica non viene fatta con .Update(), ma a mano!

            // //crea un CommandBuilder che generi automaticamente le query:
            //System.Data.Common.DbCommandBuilder commBuilder =
            //       new System.Data.SQLite.SQLiteCommandBuilder((System.Data.SQLite.SQLiteDataAdapter)dAdapter);
            //dAdapter.UpdateCommand = commBuilder.GetUpdateCommand();
            //dAdapter.InsertCommand = commBuilder.GetInsertCommand();
            //dAdapter.DeleteCommand = commBuilder.GetDeleteCommand();

            //// **** imposta i parametri per le query 
            //DbParameter IdVerbo = new SQLiteParameter("@IdVerbo", DbType.Int32, "IdVerbo");
            //DbParameter Infinito = new SQLiteParameter("@Infinito", DbType.String, "Infinito");
            //DbParameter Passato = new SQLiteParameter("@Passato", DbType.String, "Passato");
            //DbParameter ParticipioPassato = new SQLiteParameter("@ParticipioPassato", DbType.String, "ParticipioPassato");
            //DbParameter InfinitoInItaliano = new SQLiteParameter("@InfinitoInItaliano", DbType.String, "InfinitoInItaliano");

            //// **** imposta le query SQL per update, insert e delete ****
            //// UPDATE
            //dAdapter.UpdateCommand = new SQLiteCommand(
            //    "UPDATE VerbiInglesi SET [IdVerbo] = @IdVerbo, [Infinito] = @Infinito, [Passato] = @Passato, " + 
            //    "[ParticipioPassato] = @ParticipioPassato, [InfinitoInItaliano] = @InfinitoInItaliano " +
            //    "WHERE ([IdVerbo] = @IdVerbo);"
            // );

            //dAdapter.UpdateCommand.Parameters.Add(IdVerbo);
            //dAdapter.UpdateCommand.Parameters.Add(Infinito);
            //dAdapter.UpdateCommand.Parameters.Add(Passato);
            //dAdapter.UpdateCommand.Parameters.Add(ParticipioPassato);
            //dAdapter.UpdateCommand.Parameters.Add(InfinitoInItaliano);

            //// INSERT
            //// codice commentato perchè l'inserimento lo facciamo a mano!
            //dAdapter.InsertCommand = new SQLiteCommand(
            //    "INSERT INTO [VerbiInglesi] " +
            //    "([IdVerbo], [Infinito], [Passato], [ParticipioPassato], [InfinitoInItaliano])" +
            //    " VALUES (@IdVerbo, @Infinito, @Passato, @ParticipioPassato, @InfinitoInItaliano);"
            // );
            //dAdapter.InsertCommand.Parameters.Add(IdVerbo);
            //dAdapter.InsertCommand.Parameters.Add(Infinito);
            //dAdapter.InsertCommand.Parameters.Add(Passato);
            //dAdapter.InsertCommand.Parameters.Add(ParticipioPassato);
            //dAdapter.InsertCommand.Parameters.Add(InfinitoInItaliano);

            //// DELETE
            //dAdapter.DeleteCommand = new SQLiteCommand(
            //    "DELETE FROM [VerbiInglesi] " +
            //    "WHERE ([IdVerbo] = @IdVerbo) ;"
            // );
            //dAdapter.DeleteCommand.Parameters.Add(IdVerbo);
            //dAdapter.DeleteCommand.Parameters.Add(Infinito);
            //dAdapter.DeleteCommand.Parameters.Add(Passato);
            //dAdapter.DeleteCommand.Parameters.Add(ParticipioPassato);
            //dAdapter.DeleteCommand.Parameters.Add(InfinitoInItaliano);

            // lettura della tabella Verbi
            dSet = new DataSet("Verbi"); 

            dAdapter.Fill(dSet);

            //DataTable dTable = dSet.Tables["VerbiInglesi"];
            conn.Close();
        }

        public void UpdateVerbi(int CodEsercizio, ref DbDataAdapter dAdapter, ref DataSet dSet)
        {
            // riconnessione del DataAdapter
            DbConnection conn = Connetti();
            DbCommand comm = conn.CreateCommand();
            // cancellazione dalla tabella VerbiEsercizi delle righe che contengono i verbi cancellati 
            DataView dView = new DataView(dSet.Tables[0], "", "", DataViewRowState.Deleted);

            foreach (DataRowView drv in dView)
            {
                comm.CommandText = "DELETE FROM [VerbiEsercizi] WHERE ([IdVerbo] = " + drv["IdVerbo"].ToString() + ");";
                comm.ExecuteNonQuery();
                comm.CommandText = "DELETE FROM [VerbiInglesi] WHERE ([IdVerbo] = " + drv["IdVerbo"].ToString() + ");";
                comm.ExecuteNonQuery();
            }
            // aggiunta delle righe che sono state aggiunte nella tabella Esercizi e dei collegamenti nella tabella
            // intermedia VerbiEsercizi
            dView = new DataView(dSet.Tables[0], "", "", DataViewRowState.Added);
            foreach (DataRowView adv in dView)
            {
                comm.CommandText = "INSERT INTO [VerbiInglesi] " +
                "([Infinito], [Passato], [ParticipioPassato], [InfinitoInItaliano])" +
                " VALUES ('" + adv["Infinito"] + "','" + adv["Passato"] + "','" + adv["ParticipioPassato"] + 
                    "','" + adv["InfinitoInItaliano"] + "');";
                comm.ExecuteNonQuery(); 
  
                // comando che richiede al database il codice appena generato
                int newID = 0;
                //comm = conn.CreateCommand();
                comm.CommandText = "SELECT last_insert_rowid();";
                newID = int.Parse(comm.ExecuteScalar().ToString());

                // aggiunta della riga nella tabella di collegamento VerbiEsercizi
                comm.CommandText = "INSERT INTO [VerbiEsercizi] (IdVerbo, IdEsercizio) " +
                                    " VALUES (" + newID + "," + CodEsercizio + ");";
                comm.ExecuteNonQuery();
            }

            // gestione delle righe che sono state modificate
            dView = new DataView(dSet.Tables[0], "", "", DataViewRowState.ModifiedCurrent);
            foreach (DataRowView adv in dView)
            {
                comm.CommandText = "UPDATE VerbiInglesi SET [IdVerbo] = " + adv["IdVerbo"] +
                    ",[Infinito]='" + adv["Infinito"] + "',[Passato]='" + adv["Passato"] + "'," +
                    "[ParticipioPassato]='" + adv["ParticipioPassato"] + "',[InfinitoInItaliano]='"
                    + adv["InfinitoInItaliano"] + "'" +
                    " WHERE [IdVerbo] = " + adv["IdVerbo"];
                comm.ExecuteNonQuery();
            }

            // update automatico della tabella 
            //(non si fa perchè non si riescono a sapere i codici autoincrementati): 
            //dAdapter.UpdateCommand.Connection = conn;
            //dAdapter.InsertCommand.Connection = conn;
            //dAdapter.DeleteCommand.Connection = conn;

            //try 
            //{
                //dAdapter.Update(dSet.Tables[0]);
            //}
            //catch (System.InvalidOperationException)
            //{ 
            //    // non fa nulla perchè quest'eccezione è prevista
            //}
            conn.Close();
        }

        public void DataSetVerbiCheNonCiSono(int CodEsercizio, ref DbDataAdapter dAdapter, ref DataSet dSet)
        {
            DbConnection conn = Connetti();
            // verbi della tabella VerbiInglesi che non sono inclusi nell'esercizio il cui codice viene passato

            //TODO la prossima mi piacerebbe che funzionasse (una sola query invece di due)!
            //dAdapter = new SQLiteDataAdapter("SELECT VerbiInglesi.* FROM VerbiInglesi " + 
            //                                    "LEFT JOIN VerbiEsercizi " +
            //                                    "ON (VerbiInglesi.IdVerbo = VerbiEsercizi.IdVerbo " +
            //                                        "AND VerbiEsercizi.IdEsercizio = " + CodEsercizio + ") "+
            //                                    "WHERE VerbiEsercizi.IdVerbo = NULL;",
            //                                                (System.Data.SQLite.SQLiteConnection)conn);

            dAdapter = new SQLiteDataAdapter("SELECT * " + 
                                             "FROM VerbiInglesi" +
                                             " WHERE IdVerbo NOT IN" +
                                             " (Select IdVerbo FROM VerbiEsercizi" +
                                                " WHERE IdEsercizio =" + CodEsercizio + ")" +
                                                " ORDER BY Infinito;",
                                                    (System.Data.SQLite.SQLiteConnection)conn);

            // lettura della tabella Verbi
            dSet = new DataSet("Verbi");

            dAdapter.Fill(dSet);

            //DataTable dTable = dSet.Tables["VerbiInglesi"];
            conn.Close();
        }

        public void DataSetEsercizi(int CodEsercizio, ref DbDataAdapter dAdapter, ref DataSet dSet)
        {
            DbConnection conn = Connetti();
            DbCommandBuilder commBuilder = null; 
            string query = "SELECT * FROM Esercizi ORDER BY IdEsercizio;";
            switch (tipoDB)
            {
                case TipoDB.SQLite:
                    {
                        dAdapter = new SQLiteDataAdapter(query, (System.Data.SQLite.SQLiteConnection)conn);
                        // crea un CommandBuilder che generi automaticamente le query:
                        commBuilder =
                            new System.Data.SQLite.SQLiteCommandBuilder((System.Data.SQLite.SQLiteDataAdapter)dAdapter);
                        break;
                    }
                case TipoDB.Access:
                    {
                        dAdapter = new System.Data.OleDb.OleDbDataAdapter(query,
                                (System.Data.OleDb.OleDbConnection)conn);
                        // crea un CommandBuilder che generi automaticamente le query:
                        commBuilder =
                               new System.Data.OleDb.OleDbCommandBuilder((System.Data.OleDb.OleDbDataAdapter)dAdapter); 
                        break;
                    }
                default:
                    {
                        conn = null;
                        break;
                    }
             }
            dSet = new DataSet("Verbi");

            dAdapter.Fill(dSet);

            //DataTable dTable = dSet.Tables["VerbiInglesi"];
            conn.Close();

            dAdapter.UpdateCommand = commBuilder.GetUpdateCommand();
            dAdapter.InsertCommand = commBuilder.GetInsertCommand();
            dAdapter.DeleteCommand = commBuilder.GetDeleteCommand();
        }

        public void DataSetCaptionLingue(ref DbDataAdapter dAdapter, ref DataSet dSet, string lingue)
        {
            DbConnection conn = Connetti();
            DbCommandBuilder commBuilder = null;
            string query = "SELECT * FROM languages WHERE language IN( " + lingue + ");";
            switch (tipoDB)
            {
                case TipoDB.SQLite:
                    {
                        dAdapter = new SQLiteDataAdapter(query, (System.Data.SQLite.SQLiteConnection)conn);
                        // crea un CommandBuilder che generi automaticamente le query:
                        commBuilder =
                            new System.Data.SQLite.SQLiteCommandBuilder((System.Data.SQLite.SQLiteDataAdapter)dAdapter);
                        break;
                    }
                case TipoDB.Access:
                    {
                        dAdapter = new System.Data.OleDb.OleDbDataAdapter(query,
                                (System.Data.OleDb.OleDbConnection)conn);
                        // crea un CommandBuilder che generi automaticamente le query:
                        commBuilder =
                               new System.Data.OleDb.OleDbCommandBuilder((System.Data.OleDb.OleDbDataAdapter)dAdapter);
                        break;
                    }
                default:
                    {
                        conn = null;
                        break;
                    }
            }
            dSet = new DataSet("Verbi");

            dAdapter.Fill(dSet);

            //DataTable dTable = dSet.Tables["VerbiInglesi"];
            conn.Close();

            dAdapter.UpdateCommand = commBuilder.GetUpdateCommand();
            dAdapter.InsertCommand = commBuilder.GetInsertCommand();
            dAdapter.DeleteCommand = commBuilder.GetDeleteCommand();
        }

        public ArrayList LinguePresenti()
        {
            DbConnection conn = Connetti();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT language FROM languages";
            DbDataReader reader = cmd.ExecuteReader();
            ArrayList ling = new ArrayList();
            while (reader.Read())
            {
                ling.Add(reader[0]);
            }
            conn.Close();
            return ling; 
        }

        public Hashtable Prompts(string lingua)
        {
            DbConnection conn = Connetti();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM languages WHERE language='" + lingua + "';";
            DbDataReader reader = cmd.ExecuteReader();
            Hashtable p = new Hashtable();
            reader.Read(); 
            for (int i=0; i<reader.FieldCount;i++)
            {
                p.Add(reader.GetName(i) , reader[i].ToString());
            }
            conn.Close();
            return p;
        }
        #endregion

        public void NuovaLingua(string newLanguage)
        {
            DbConnection conn = Connetti();
            DbCommand cmd = conn.CreateCommand();
            // TODO mettere automaticamente le caption di default
            // aggiunta della riga del linguaggio alla tabella delle caption
            cmd.CommandText = "INSERT INTO languages (language) VALUES  ('" + newLanguage + "');";
            cmd.ExecuteNonQuery();

            // aggiunta della colonna alla tabella VerbiInglesi
            cmd.CommandText = "ALTER TABLE VerbiInglesi ADD COLUMN Inf" + newLanguage + " TEXT;";
            cmd.ExecuteNonQuery();
        }
    }
}
