using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSU21.Helpers
{
    public class Allergies
    {
        #region Enums
        [Flags]
        public enum Allergen
        {
            Eggs = 1,
            Peanuts = 2,
            Shellfish = 4,
            Strawberries = 8,
            Tomatoes = 16,
            Chocolate = 32,
            Pollen = 64,
            Cats = 128,
            // Fruits = Strawberries | Tomatoes
        }
        #endregion
        #region Properties
        public string Name { get; }
        public int Score => SumScore();
        #endregion

        #region Fields
        private readonly List<Allergen> _allergens = new List<Allergen>();
        #endregion

        #region Public methods

        public Allergies(string name)
        {
            Name = name;
        }

        public Allergies(string name, string allergies) : this(name)
        {
            string[] allergenes = allergies.Split();

            foreach (var allergene in allergenes)
            {
                Enum.TryParse(allergene, out Allergen allergy);
                _allergens.Add(allergy);
            }
            _allergens = _allergens.OrderBy(x => (int)x).ToList();
        }

        public Allergies(string name, int allergyScore) : this(name)
        {
            ExtractAllergiesFromScore(allergyScore);
        }

        public void AddAllergy(Allergen allergen)
        {
            _allergens.Add(allergen);
        }
        public void AddAllergy(string allergy)
        {
            Allergen allergen = GetAllergenByName(allergy);
            _allergens.Add(allergen);
        }



        public void DeleteAllergy(string allergy)
        {
            Allergen allergen = GetAllergenByName(allergy);
            _allergens.Remove(allergen);
        }
        public void DeleteAllergy(Allergen allergen)
        {
            _allergens.Remove(allergen);
        }

        public bool IsAllergicTo(string allergy)
        {
            Allergen allergen = GetAllergenByName(allergy);
            return IsAllergicTo(allergen);
        }
        public bool IsAllergicTo(Allergen allergen)
        {
            foreach (var allergy in _allergens)
            {
                if (allergy.HasFlag(allergen))
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            if (Score == 0)
            {
                return $"{Name} has no allergies!";

            }
            return $"{Name} is allergic to {GetAllergiesString()}";
        }
        #endregion


        #region Private methods
        private static Allergen GetAllergenByName(string allergy)
        {
            Enum.TryParse(allergy, out Allergen allergen);
            return allergen;
        }
        private void ExtractAllergiesFromScore(int totalScore)
        {
            foreach (Allergen allergen in Enum.GetValues(typeof(Allergen)))
            {
                if (((Allergen)totalScore).HasFlag(allergen))
                {
                    _allergens.Add(allergen);
                }
            }
        }
        private string GetAllergiesString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < _allergens.Count; i++)
            {
                if (i > 0 && i < _allergens.Count - 1) // inte sista allergin alltså
                {
                    output.Append(", ");
                }
                else if (i == _allergens.Count - 1 && _allergens.Count > 1)
                {
                    output.Append(" and ");
                }
                output.Append(_allergens[i]);

            }
            output.Append(".");
            return output.ToString();
        }
        private int SumScore()
        {
            int score = 0;
            foreach (var allergene in _allergens)
            {
                score += (int)allergene;
            }
            return score;
        }
        #endregion
    }
}
