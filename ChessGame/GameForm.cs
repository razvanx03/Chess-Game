using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ChessGame
{
    public partial class GameForm : Form
    {
        private Board board { get; set; }

        public GameForm()
        {
            InitializeComponent();
        }

        //minimum form size
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            board?.Rescale(Width, Height, Menu.Height);
        }

        // menu items
        private void Play_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                Controls.Remove(board);
                board.Dispose();
            }

            board = new Board();
            Controls.Add(board);
            OnResize(e);

            Game chessGame = new Chess();
            chessGame.Initialise(board);
            chessGame.Start();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented // debug
                };

                DataAdaptor jsonData = new DataAdaptor(board.GetContext());
                string json = JsonConvert.SerializeObject(jsonData, settings);

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(documentsPath, "table.json");

                File.WriteAllText(filePath, json);
            }
            else
            {
                MessageBox.Show("Tabla de sah nu este initializata","Eroare",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(documentsPath, "table.json");
                string json = File.ReadAllText(filePath);

                JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(json);

                if (board != null)
                {
                    Controls.Remove(board);
                    board.Dispose();
                }

                board = new Board();
                Controls.Add(board);
                OnResize(e);

                Game chessGame = new Chess();
                chessGame.Initialise(board);
                chessGame.LoadFromFile(jsonData);

            } 
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nu exista nicio tabla salvata", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}