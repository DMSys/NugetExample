using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ngSQLite
{
    public partial class FSQLite : Form
    {
        private String _DataSource = "";

        public FSQLite()
        {
            InitializeComponent();

            _DataSource = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TestBase.db");
            
        }

        private void btn_Initialize_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteDatabase db = new SQLiteDatabase(_DataSource))
                {
                    db.Open();

                    string commandText =
@"CREATE TABLE artist
  (
    artistid    INTEGER PRIMARY KEY, 
    artistname  TEXT
  );
  CREATE TABLE track
  (
    trackid     INTEGER, 
    trackname   TEXT, 
    trackartist INTEGER,
    likecount   INTEGER,
    FOREIGN KEY(trackartist) REFERENCES artist(artistid)
  );
  CREATE INDEX trackindex ON track(trackartist);
  CREATE TABLE song(
    songid     INTEGER,
    songartist TEXT,
    songalbum TEXT,
    songname   TEXT,
    FOREIGN KEY(songartist, songalbum) REFERENCES album(albumartist, albumname)
  );
  INSERT INTO artist (artistid, artistname) VALUES ( 1, 'Dean Martin');
  INSERT INTO artist VALUES( 2, 'Frank Sinatra');";
                    db.ExecuteNonQuery(commandText);

                    db.Insert("track", new Dictionary<string, string>
                    {
                        { "trackid", "11"},
                        { "trackname", "That's Amore"},
                        { "trackartist", "1"},
                        { "likecount", "0"}
                    });
                    db.Insert("track", new Dictionary<string, string>
                    {
                        { "trackid", "12"},
                        { "trackname", "Christmas Blues"},
                        { "trackartist", "1"},
                        { "likecount", "0"}
                    });
                    db.Insert("track", new Dictionary<string, string>
                    {
                        { "trackid", "13"},
                        { "trackname", "My Way"},
                        { "trackartist", "2"},
                        { "likecount", "0"}
                    });
                    db.Insert("track", new List<string> { "14", "The Way You Look Tonight", "2", "0" });
                    db.Insert("track", new List<string> { "15", "I Could Have Danced All Night", "2", "0" });

                    db.Vacuum();
                    db.Close();
                }
                MessageBox.Show("Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " : " + ex.Message);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteDatabase db = new SQLiteDatabase(_DataSource))
                {
                    db.Open();

                    db.Clear();

                    db.Close();
                }
                MessageBox.Show("Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " : " + ex.Message);
            }
        }

        private void btn_DropTables_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteDatabase db = new SQLiteDatabase(_DataSource))
                {
                    db.Open();

                    List<String> tables = db.ListTablesName();
                    foreach (String tableName in tables)
                    {
                        db.DropTable(tableName);
                    }

                    db.Close();
                }
                MessageBox.Show("Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " : " + ex.Message);
            }
        }

        private void btn_DropDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteDatabase db = new SQLiteDatabase(_DataSource))
                {
                    db.DropDatabase();
                }
                MessageBox.Show("Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " : " + ex.Message);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteDatabase db = new SQLiteDatabase(_DataSource))
                {
                    db.Open();

                    db.Update("track",
                        new Dictionary<string, string>
                        {
                            { "likecount", "likecount + 1"}
                        },
                        "trackid = 13");
                    
                    db.Close();
                }
                MessageBox.Show("Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " : " + ex.Message);
            }
        }

        private void btn_TransactionCommit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteDatabase db = new SQLiteDatabase(_DataSource))
                {
                    db.Open();
                    db.TransactionBegin();
                    try
                    {
                        db.Update("track",
                            new Dictionary<string, string>
                        {
                            { "likecount", "likecount + 1"}
                        },
                            "trackid = 13");

                        db.TransactionCommit();
                    }
                    catch (Exception ex)
                    {
                        db.TransactionRollback();
                        throw ex;
                    }
                    db.Close();
                }
                MessageBox.Show("Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " : " + ex.Message);
            }
        }

        private void btn_TransactionRollback_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteDatabase db = new SQLiteDatabase(_DataSource))
                {
                    db.Open();
                    db.TransactionBegin();
                    try
                    {
                        db.Update("track",
                            new Dictionary<string, string>
                        {
                            { "likecount1", "likecount + 1"}
                        },
                            "trackid = 13");

                        db.TransactionCommit();
                    }
                    catch (Exception ex)
                    {
                        db.TransactionRollback();
                        throw ex;
                    }
                    db.Close();
                }
                MessageBox.Show("Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString() + " : " + ex.Message);
            }
        }
    }
}
