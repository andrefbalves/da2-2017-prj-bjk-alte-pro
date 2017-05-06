using System;
using System.Collections;

namespace O_Meu_Namespace
{
    // Alterar namespace em cima...


    // NÃO ALTERAR ESTA CLASSE
    // Se necessitarem de trabalhar dados provenientes das cartas, façam-no noutra classe (encapsulamento).
    // Em último caso falar com docente, please. Excepção: traduzir textos, caso faça sentido.

    /// <summary>
    /// Object Representing a playing card. Card has a numeric value and a suit.
    /// </summary>

    public class Card : IComparable, IEquatable<Card>
    {
        #region "Fields"
        public int ID { get; set; }
        public enum Suits { Clubs, Diamonds, Hearts, Spades }
        public enum Faces { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }


        private Suits _suit;
        private Faces _face;
        private readonly int[] _values = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the suit of the PlayingCards.Card.
        /// </summary>
        public Suits Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        /// <summary>
        /// Gets the face value of the PlayingCards.Card.
        /// </summary>
        public Faces Face
        {
            get { return _face; }
            set { _face = value; }
        }

        /// <summary>
        /// Gets the numeric value of the PlayingCards.Card.
        /// </summary>
        public int Value
        {
            get { return _values[(int)Face]; }
        }
        #endregion

        #region "Constructors"
        /// <summary>
        /// Create a Card of random value.
        /// </summary>
        public Card()
        {
            Random random = new Random();
            Face = (Faces)random.Next(0,12);
            Suit = (Suits)random.Next(0,3);
        }

        
        /// <summary>
        /// Create an object of type Card based on a value between 0-51.
        /// </summary>
        /// <param name="cardValue">The value of the Card, 0-51.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">value is less than zero or greater than 51.</exception>
        public Card(int cardValue)
        {
            if (cardValue > 51 || cardValue < 0) { throw new ArgumentOutOfRangeException(String.Format("Invalid Card value of {0}.  Please use values of 0-51.", cardValue)); }
            else 
            { 
                Suit = (Suits)(((cardValue) / 13));
                Face = (Faces)(((cardValue) % 13));
            }
        }


        /// <summary>
        /// Creates an object of type Card.
        /// </summary>
        /// <param name="face">The face of the Card.</param>
        /// <param name="suit">The suit of the Card.</param>
        public Card(Faces face, Suits suit)
        {
            Face = face;
            Suit = suit;
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Creates a shallow copy of the Cards.Card.
        /// </summary>
        /// <returns>A shallow copy of the PlayingCards.Card.</returns>
        public object Clone()
        {
            return new Card(Face, Suit);
        }


        /// <summary>
        /// Compares this instance with a specified System.Object.
        /// </summary>
        /// <param name="obj">value: An System.Object that evaluates to a PlayingCards.Card.</param>
        /// <returns>A 32-bit signed integer indicating the lexical relationship between the two comparands.Value Condition Less than zero This instance is less than value. Zero This instance is equal to value. Greater than zero This instance is greater than value.-or- value is null.</returns>
        /// <exception cref="System.ArgumentException">value is not a PlayingCards.Card.</exception>
        public int CompareTo(Object obj)
        {
            if (obj is Card)
            {
                Card card = (Card)obj;

                if ( Equals(obj) ) { return 0; }
                else if (card.Value < Value) { return 1; }
                else if (card.Value > Value) { return -1; }
                else { return 0; }
            }
            else { throw new ArgumentException("Object is not of type Card."); }
        }

        
        /// <summary>
        /// Returns true if this Card and the specified Card are equal in both value and suit.
        /// </summary>
        /// <param name="card">A PlayingCards.Card.</param>
        /// <returns>true if the Card's suit, face, and value are equal.</returns>
        public Boolean Equals(Card card)
        {
            if ( Suit.Equals(card.Suit) && Face.Equals(card.Face) && Value.Equals(card.Value) ) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Returns the alias of the Card's suit.
        /// </summary>
        /// <returns>The card's suit as a string.</returns>
        public string GetSuitAlias()
        {
            switch (Suit)
            {
                case Suits.Clubs: return "Clubs";
                case Suits.Diamonds: return "Diamonds";
                case Suits.Hearts: return "Hearts";
                case Suits.Spades: return "Spades";
                default: return "??";
            }
        }

        public string GetSuitAliasMin()
        {
            switch (Suit)
            {
                case Suits.Clubs: return "clubs";
                case Suits.Diamonds: return "diams";
                case Suits.Hearts: return "hearts";
                case Suits.Spades: return "spades";
                default: return "??";
            }
        }


        /// <summary>
        /// Returns the alias of the cards value.
        /// </summary>
        /// <returns>The string representation of the card's value.</returns>
        public string GetFaceAlias()
        {
            switch (Face)
            {
                case Faces.Ace: return "Ace";
                case Faces.Two: return "2";
                case Faces.Three: return "3";
                case Faces.Four: return "4";
                case Faces.Five: return "5";
                case Faces.Six: return "6";
                case Faces.Seven: return "7";
                case Faces.Eight: return "8";
                case Faces.Nine: return "9";
                case Faces.Ten: return "10";
                case Faces.Jack: return "Jack";
                case Faces.Queen: return "Queen";
                case Faces.King: return "King";
                default: return "??";
            }
        }

        public string GetFaceAliasMin()
        {
            switch (Face)
            {
                case Faces.Ace: return "a";
                case Faces.Two: return "2";
                case Faces.Three: return "3";
                case Faces.Four: return "4";
                case Faces.Five: return "5";
                case Faces.Six: return "6";
                case Faces.Seven: return "7";
                case Faces.Eight: return "8";
                case Faces.Nine: return "9";
                case Faces.Ten: return "10";
                case Faces.Jack: return "j";
                case Faces.Queen: return "q";
                case Faces.King: return "k";
                default: return "??";
            }
        }


        /// <summary>
        /// Converts this Cards.Card to a human-readable string.
        /// </summary>
        /// <returns>A string that represents this PlayingCards.Card.</returns>
        public override String ToString()
        {
            return GetFaceAlias() + " of " + GetSuitAlias();
        }
        #endregion
    }
}