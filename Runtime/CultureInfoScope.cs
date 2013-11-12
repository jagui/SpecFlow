using System;
using System.Globalization;
using System.Threading;
using TechTalk.SpecFlow.Tracing;

namespace TechTalk.SpecFlow
{
    public class CultureInfoScope : IDisposable
    {
#if !WINRT
        private readonly CultureInfo originalCultureInfo;
#endif
        public CultureInfoScope(CultureInfo cultureInfo)
        {
#if !WINRT
            if (cultureInfo != null && !cultureInfo.Equals(Thread.CurrentThread.CurrentCulture))
            {
                if (cultureInfo.IsNeutralCulture)
                {
                    cultureInfo = LanguageHelper.GetSpecificCultureInfo(cultureInfo);
                }
                originalCultureInfo = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = cultureInfo;
            }
#endif
        }

        public void Dispose()
        {
#if !WINRT
            if (originalCultureInfo != null)
                Thread.CurrentThread.CurrentCulture = originalCultureInfo;
#endif
        }
    }
}