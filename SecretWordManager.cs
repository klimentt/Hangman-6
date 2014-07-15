namespace HangmanSix
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    /// <summary>
    /// Keeps all possible secret words
    /// </summary>
    public class SecretWordManager : IExpandable, IRemovable
    {
        private List<string> allSecretWords = new List<string>();

        public void LoadAllSecretWords(string path)
        {
            try
            {
                string[] words = File.ReadAllLines(path);
                foreach (string line in words)
                {
                    allSecretWords.AddRange(line.Split(','));
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The word library was not found!");
            }
            catch (FileLoadException)
            {
                throw new FileLoadException("Unable to load word library!");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("The path specified is too long!");
            }
            catch (Exception e)
            {
                throw new Exception("An Error occured in: " + e.StackTrace);
            }
        }

        public List<string> GetAllSecretWords()
        {
            return this.allSecretWords;
        }

        public void Remove(int index)
        {
            allSecretWords.RemoveAt(index);
        }

        public void Add(string newSecretWord)
        {
            allSecretWords.Add(newSecretWord);
        }
    }
}
