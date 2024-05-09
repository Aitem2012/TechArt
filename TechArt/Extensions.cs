namespace TechArt
{
    public static class Extensions
    {
        /// <summary>
        /// Generates a Slug text from a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Slugify(this string str)
        {
            return str.ToLower().Replace(" ", "-").Replace(".", "").Replace("/", "-").Replace("\\", "-").Replace("@", "-").Replace("!", "").Replace(",", "").Replace("~", "").Replace("`", "").Replace("'", "").Replace("\"", "").Replace("#", "").Replace("&", "") + Guid.NewGuid().ToString().Substring(0, 12);
        }

        /// <summary>
        /// Generate References, appends random text to a specified text
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GenerateRef(this string str)
        {
            return $"{str}{Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 10)}";
        }

        /// <summary>
        /// Generates ReferralCode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GenerateReferralCode(this string str)
        {
            return $"{str}{Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 7)}";
        }

        /// <summary>
        /// Converts a Boolean Value to Yes or No string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }

        /// <summary>
        /// Converts a Boolean Value to True or False string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTrueFalse(this bool value)
        {
            return value ? "True" : "False";
        }

        /// <summary>
        /// Gets an Enum string description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null)
            {
                return null;
            }
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute?.Description;
        }

        /// <summary>
        /// Gets age calculation for the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int ToAge(this DateTime date)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - date.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (date.Date > today.AddYears(-age)) age--;

            return age;
        }

        /// <summary>
        /// Gets the time ago calculation for the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string TimeAgo(this DateTime date)
        {
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * minute)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * minute)
                return "a minute ago";

            if (delta < 45 * minute)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * minute)
                return "an hour ago";

            if (delta < 24 * hour)
                return ts.Hours + " hours ago";

            if (delta < 48 * hour)
                return "yesterday";

            if (delta < 30 * day)
                return ts.Days + " days ago";

            if (delta < 12 * month)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        /// <summary>
        /// Formats Long to String format 1H, 1K, 1M, 1B, 1T
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string LongToNumberFormat(this long num)
        {
            // Ensure number has max 3 significant digits (no rounding up can happen)
            long i = (long)Math.Pow(10, (int)Math.Max(0, Math.Log10(num) - 2));
            num = num / i * i;

            if (num >= 1000000000000)
                return (num / 1000000000000D).ToString("0.##") + "T";
            if (num >= 1000000000)
                return (num / 1000000000D).ToString("0.##") + "B";
            if (num >= 1000000)
                return (num / 1000000D).ToString("0.##") + "M";
            if (num >= 1000)
                return (num / 1000D).ToString("0.##") + "K";

            return num.ToString("#,0");
        }

        /// <summary>
        /// gets the subjectID for a principal
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetSubjectId(this IPrincipal principal)
        {
            return principal.Identity.GetSubjectId();
        }

        /// <summary>
        /// gets the subjectID for an Identity
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string GetSubjectId(this IIdentity identity)
        {
            var id = identity as ClaimsIdentity;
            var claim = id?.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                throw new InvalidOperationException("sub claim is missing");
            }
            return claim.Value;
        }

        /// <summary>
        /// Generates the Page Sized List of Records or Entities Needed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="records"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static List<T> ToPageSize<T>(this List<T> records, int pageIndex, int pageSize) where T : class
        {
            return records.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// check if a class is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T value) where T : class
        {
            return value == null;
        }

        /// <summary>
        /// Check if a string is empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    }
}