using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayFair
{
    class Polyalphabetic
    {
        Alphabet alph = new Alphabet();

        public string Encrypt(string sourcetext, string key)
        {
            StringBuilder code = new StringBuilder();
            sourcetext = sourcetext.ToLower().Replace(" ", "");
            key = key.ToLower().Replace(" ", "");
            int[] key_id = new int[key.Length];
            int t = 0;

            //search for indexes of letters of a key
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < alph.lang.Length; j++)
                {
                    if (key[i] == alph.lang[j])
                    {
                        key_id[i] = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < sourcetext.Length; i++)
            {
                //searching for a character in the alphabet
                for (int j = 0; j < alph.lang.Length; j++)
                {
                    //if the symbol is found
                    if (sourcetext[i] == alph.lang[j])
                    {
                        if (t > key.Length - 1)
                        {
                            t = 0;
                        }
                        code.Append(alph.lang[(j + key_id[t]) % alph.lang.Length]);
                        t++;

                        break;
                    }
                    //if the symbol is not found
                    else if (j == alph.lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                        t++;
                    }
                }
            }

            return code.ToString();
        }

        public string Decrypt(string sourcetext, string key)
        {
            StringBuilder code = new StringBuilder();
            int[] key_id = new int[key.Length];
            int t = 0;

            //search for indexes of letters of a key
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < alph.lang.Length; j++)
                {
                    if (key[i] == alph.lang[j])
                    {
                        key_id[i] = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < sourcetext.Length; i++)
            {
                //searching for a character in the alphabet
                for (int j = 0; j < alph.lang.Length; j++)
                {
                    //if the symbol is found

                    if (sourcetext[i] == alph.lang[j])
                    {
                        if (t > key.Length - 1)
                        {
                            t = 0;
                        }
                        code.Append(alph.lang[(j + alph.lang.Length - key_id[t]) % alph.lang.Length]);
                        t++;
                        break;
                    }
                    //if the symbol is not found
                    else if (j == alph.lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                        t++;
                    }
                }
            }

            return code.ToString();
        }
    }
}
