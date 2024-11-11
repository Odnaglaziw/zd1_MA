using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playlist
{
    public partial class Form1 : Form
    {
        private Playlist playlist;
        public Form1()
        {
            InitializeComponent();
            playlist = new Playlist();
            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
        }

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                string author = e.Item.SubItems[0].Text;
                string tittle = e.Item.SubItems[1].Text;
                prevName.Text = tittle;
                prevNumber.Text = author;
                newName.Text = string.Empty;
                newAuthor.Text = string.Empty;
                AddBtn.Enabled = false;
                AddBtn.Visible = false;
                DelBtn.Enabled = true;
                DelBtn.Visible = true;
                tabControl1.SelectedIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            newName.Text = string.Empty;
            newAuthor.Text = string.Empty;
            prevName.Text = string.Empty;
            prevNumber.Text = string.Empty;
            AddBtn.Enabled = true;
            AddBtn.Visible = true;
            DelBtn.Enabled = false;
            DelBtn.Visible = false;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            playlist.AddSong(new Song {Author = newAuthor.Text, Filename = newName.Text, Title = newName.Text });
            DataUpdate(playlist.GetAllSongs());
            Display.Text = playlist.CurrentSong().Title;
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            playlist.RemoveSong(new Song { Author = newAuthor.Text, Filename = newName.Text, Title = newName.Text });
        }

        private void next_Click(object sender, EventArgs e)
        {
            playlist.Next();
            Display.Text = playlist.CurrentSong().Title;
        }

        private void prev_Click(object sender, EventArgs e)
        {
            playlist.Previous();
            Display.Text = playlist.CurrentSong().Title;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataUpdate(playlist.GetAllSongs());
            tabControl1.SelectedIndex = 1;
            newName.Text = string.Empty;
            newAuthor.Text = string.Empty;
        }
        private void DataUpdate(List<Song> songs)
        {
            listView1.Items.Clear();
            if (songs.Count > 0)
            listView1.Items.AddRange(
                songs.Select(s => new ListViewItem(new string[] { s.Author, s.Title })).ToArray());
        }
    }
}
