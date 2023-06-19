# TechArt

string slug = "Hello World!".Slugify();
// Output: "hello-world-<12-character-guid>"

string reference = "Reference".GenerateRef();
// Output: "Reference<10-character-uppercase-guid>"
string referralCode = "Code".GenerateReferralCode();
// Output: "Code<7-character-uppercase-guid>"
bool value = true;
string yesNo = value.ToYesNo();
// Output: "Yes"
bool value = false;
string trueFalse = value.ToTrueFalse();
// Output: "False"
enum Status
{
    [Description("Active status")]
    Active,
    [Description("Inactive status")]
    Inactive
}

Status status = Status.Active;
string description = status.GetDescription();
// Output: "Active status"
DateTime birthdate = new DateTime(1990, 1, 1);
int age = birthdate.ToAge();
// Output: <current age based on birthdate>
DateTime pastDate = DateTime.Now.AddHours(-3);
string timeAgo = pastDate.TimeAgo();
// Output: "3 hours ago"
long number = 1500000;
string formattedNumber = number.LongToNumberFormat();
// Output: "1.5M"


Available methods and their usages
1. slugify(this string str): Generates a Slug text from a string.
2. GenerateRef(this string str): Generate References, appends random text to a specified text.
3. GenerateReferralCode(this string str): Generates ReferralCode.
4. ToYesNo(this bool value): Converts a Boolean Value to Yes or No string.
5. ToTrueFalse(this bool value): Converts a Boolean Value to Yes or No string.
6. GetDescription(this Enum value): Gets an Enum string description.
7. ToAge(this DateTime date): Gets age calculation for the specified date.
8. TimeAgo(this DateTime date): Gets the time ago calculation for the specified date.
9. LongToNumberFormat(this long num): Formats Long to String format 1H, 1K, 1M, 1B, 1T.
10. GetSubjectId(this IPrincipal principal): gets the subjectID for a principal.
11. GetSubjectId(this IIdentity identity): gets the subjectID for an Identity.
12. List<T> ToPageSize<T>(this List<T> records, int pageIndex, int pageSize): Generates the Page Sized List of Records or Entities Needed.

The following responses are available for your API modelling.
1. BaseResponse<T>().CreateResponse(string message, bool status, T object).
2. PaginatedResponse<T>{Items => List<T>, TotalRecords, CurrentPage, PageSize }
