using System.Data;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

internal class Program
{
    abstract class FinincialInstrument
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public DateAndTime PurchaseDate { get; set; }
        public abstract decimal CalculateCurrentValue();
        public virtual string GetInstrumentSummary();
    }
}
