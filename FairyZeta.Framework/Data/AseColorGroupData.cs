using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.Framework.Data
{
    public class AseColorGroupData : _BlockData, IEnumerable<AseColorEntryData>
    {
        #region Constructors

        public AseColorGroupData()
        {
            this.Colors = new AseColorEntryCollection();
        }

        #endregion

        #region Properties

        public AseColorEntryCollection Colors { get; set; }

        #endregion

        #region IEnumerable<ColorEntry> Interface

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<AseColorEntryData> GetEnumerator()
        {
            return this.Colors.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
