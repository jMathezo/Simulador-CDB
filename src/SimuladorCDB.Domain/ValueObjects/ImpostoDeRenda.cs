namespace SimuladorCDB.Domain.ValueObjects
{
    public class ImpostoDeRenda : ValueObject
    {
        public int Meses { get; private set; }
        public double Percentual { get; private set; }

        public ImpostoDeRenda(int meses, double percentual)
        {
            Meses = meses;
            Percentual = percentual;
        }

        public readonly static ImpostoDeRenda Ate6Meses = new(6, 22.5);
        public readonly static ImpostoDeRenda Ate12Meses = new(12, 20);
        public readonly static ImpostoDeRenda Ate24Meses = new(24, 17.5);
        public readonly static ImpostoDeRenda Acima24Meses = new(10000, 15);

        public static double GetPercentualIR(int meses)
        {
            switch (meses)
            {   
                case <=6:
                    return Ate6Meses.Percentual;
                case <= 12:
                    return Ate12Meses.Percentual;
                case <= 24:
                    return Ate24Meses.Percentual;
                case >24:
                    return Acima24Meses.Percentual;
            }
        }
    }
}
