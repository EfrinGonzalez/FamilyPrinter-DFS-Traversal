using FamilyPrinter.Services;
using FamilyPrinter.Utils;

namespace FamilyPrinter {
    public class FamilyPrinterService : IFamilyPrinter
    {
        /// <summary>
        /// Change this method any way you want.
        /// The code should also work for children of great great granddad.
        /// </summary>
        public string Print( Ancestor a ) {
            return FamilyTreeUtils.PrintFamilyTree(a, "");
        }    

    }

}
