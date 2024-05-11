/*
    Exceeds requirements
    -It only hide words that aren't already hidden
    -A prefix can be added before a word to prevent it from being hidden
        -If theprefix is '%', '%word' won't be hidden, but will always be displayed as 'word'
    -the user is able to choose to pick a verse from the list, input their own verse or use a randomely generated verse
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Memorizer memorizer = new Memorizer();

        memorizer.ManageIO();
    }
}