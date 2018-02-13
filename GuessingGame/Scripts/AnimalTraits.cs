using System.Collections.Generic;

namespace GuessingGame.Scripts
{
    public class AnimalTraits
    {
        public AnimalTraits()
        {
            AnimalTraitsList = new List<string>
            {
                "lives in water"
            };
        }

        private List<string> m_AnimalTraits;
        public List<string> AnimalTraitsList { get => m_AnimalTraits; set => m_AnimalTraits = value; }
    }
}