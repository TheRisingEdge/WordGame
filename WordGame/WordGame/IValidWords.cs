namespace WordGame
{
    public interface IValidWords
    {
        /// <summary>
        ///     Gets the size of the valid words collection.
        /// </summary>
        int Size { get; } 
            // I would say that this property is not necessary and would remove it from the interface.
            // I would keep the responsability of this interface to only check if a word is valid.
            // This can expose details of implementation; makes the assumption that all the words are loaded into memory and can be counted;

        /// <summary>
        ///     Checks if a word is valid
        /// </summary>
        /// <param name="word">the word to check against the valid words collection</param>
        /// <returns>true if the valid words collection contains the word</returns>
        bool Contains(string word);
    }
}
