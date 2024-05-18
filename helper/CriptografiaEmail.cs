using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.helper
{

    public class CriptografiaEmail
    {
        [HttpGet("{paralelepipedo}")]
        public ActionResult<IEnumerable<char>> AnalyzeWord(string word)
        {
            
            // Convertendo a palavra para um array de letras
            var letters = new List<char>();
            foreach (char letter in word)
            {
                if (letter == 'a')
                {
                    letters.Add('w');
                }
                else
                {
                    letters.Add(letter);
                }
            }

            return (letters);
        }
    }
}
