using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PlayingCard;

namespace MemoryGame
{
    public partial class MemoryGame : Form
    {
        const int CARD_WIDTH = 75;
        const int CARD_HEIGHT = 107;
        const int NUM_COL = 8;

        Deck deck;
        PictureBox[] mycards;

        public MemoryGame()
        {
            InitializeComponent();
        }

        private void MemoryGame_Load(object sender, EventArgs e) // FORM
        {
            mycards = new PictureBox[32];
            deck = new Deck();
            List<Image> images = new List<Image>();

            for (int i = 1; i <= 52; i++)
            {
                images.Add(imageList.Images[i]);
            }

            deck.AssignImage(images, imageList.Images[0]);

            for (int i = 0; i < 32; i++)
            {
                PlayingCards card = deck.DealTopCard();
                PictureBox box = new PictureBox();
                box.Height = CARD_HEIGHT;
                box.Width = CARD_WIDTH;
                box.Size = new Size(CARD_WIDTH, CARD_HEIGHT);
                int row = i / NUM_COL;
                int col = i % NUM_COL;
                box.Location = new Point(40 + col * CARD_WIDTH, 10 + row * CARD_HEIGHT);
                mycards[i] = box;
                box.Image = card.BackImage;
                box.Tag = card;
                box.Click += Box_Click1; ;
                this.Controls.Add(box);
            }
        }

        private void Box_Click1(object sender, EventArgs e)
        {
            PictureBox box = sender as PictureBox;
            PlayingCards card = box.Tag as PlayingCards;
            card.Flip();
            box.Image = card.GetImage();

            bool check = true;
            check = !check;
        }
    }
}
