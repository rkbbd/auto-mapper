namespace AutoMapperApp
{
    public class Mapper<TSource, TDestination>
    {
        public TDestination Map(TSource source)
        {
            var destination = Activator.CreateInstance<TDestination> ();
            foreach (var sProperty in typeof(TSource).GetProperties())
            {
                var dProperty = typeof(TDestination).GetProperty(sProperty.Name);
                if (dProperty != null)
                {
                    dProperty.SetValue (destination, sProperty.GetValue(source));
                }
            }
            return destination;
        }
        public List<TDestination> Map(List<TSource> sources)
        {
           return sources.Select(source => Map(source)).ToList();
        }

    }
}