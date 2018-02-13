using System;
using System.Windows.Forms;
using GuessingGame.Scripts;
using Microsoft.VisualBasic;

namespace GuessingGame
{
    public partial class Form1 : Form
    {
        private AnimalTraits animalTraits = new AnimalTraits();
        private AnimalNames animalNames = new AnimalNames();
        private int indexAnimal = 0;
        private bool isLastQuestionAnimalTraits = false;
        private string newAnimalNameAux;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowQuestionStartGame();
        }

        public void WindowQuestionStartGame()
        {
            var dialogResult = MessageBox.Show("Think about an animal", "Guessing Name", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.Cancel)
                Application.Exit();
            else
            {
                indexAnimal = 0;
                isLastQuestionAnimalTraits = false;
                WindowQuestionAnimalTraits();
            }
        }

        public void WindowQuestionAnimalTraits()
        {
            var dialogResult = new DialogResult();

            if (indexAnimal < animalTraits.AnimalTraitsList.Count)
            {
                var message = string.Format("Does the animal that you thought about {0} ?", animalTraits.AnimalTraitsList[indexAnimal]);
                dialogResult = MessageBox.Show(message, "Guessing Name", MessageBoxButtons.YesNo);
            }

            if (dialogResult == DialogResult.Yes)
                WindowQuestionAnimalNames();
            else
            {
                if (indexAnimal < animalTraits.AnimalTraitsList.Count)
                {
                    indexAnimal++;
                    WindowQuestionAnimalTraits();
                }
                else
                {
                    isLastQuestionAnimalTraits = true;
                    WindowQuestionAnimalNames();
                }
            }
        }

        public void WindowQuestionAnimalNames()
        {
            if (isLastQuestionAnimalTraits)
            {
                var message = string.Format("Is the animal that you thought about a {0} ?", "monkey");
                var dialogResult = MessageBox.Show(message, "Guessing Name", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                    WindowWinMachine();
                else
                    WindowQuestionWhatAnimalName();

                isLastQuestionAnimalTraits = false;
            }
            else
            {
                var message = string.Format("Is the animal that you thought about a {0} ?", animalNames.AnimalNamesList[indexAnimal]);
                var dialogResult = MessageBox.Show(message, "Guessing Name", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                    WindowWinMachine();
                else
                    WindowQuestionWhatAnimalName();
            }
        }

        public void WindowQuestionWhatAnimalName()
        {
            var newAnimalName = Interaction.InputBox("What was animal that thought about ?", "Guessing Game");

            if (string.IsNullOrEmpty(newAnimalName))
                WindowQuestionStartGame();

            newAnimalNameAux = newAnimalName;
            animalNames.AnimalNamesList.Add(newAnimalName);
            WindowQuestionWhatAnimalTraits();
        }

        public void WindowQuestionWhatAnimalTraits()
        {
            var question = string.Format("A {0} but a monkey does not(Fill it with an animal trait, like 'lives in water').", newAnimalNameAux);
            string newAnimalTrait;

            do
            {
                newAnimalTrait = Interaction.InputBox(question, "Guessing Game");
            }
            while (string.IsNullOrEmpty(newAnimalTrait));

            animalTraits.AnimalTraitsList.Add(newAnimalTrait);
            WindowQuestionStartGame();
        }

        public void WindowWinMachine()
        {
            var dialogResult = MessageBox.Show("I win again!", "Guessinng Game", MessageBoxButtons.OK);

            if (dialogResult == DialogResult.OK)
                WindowQuestionStartGame();
        }
    }
}