using System.Collections.Generic;

namespace GuessingGame.Scripts
{
    public class AnimalNames
    {
        public AnimalNames()
        {
            AnimalNamesList = new List<string>()
            {
                "shark"
            };
        }

        private List<string> m_AnimalNames;
        public List<string> AnimalNamesList { get => m_AnimalNames; set => m_AnimalNames = value; }
    }
}