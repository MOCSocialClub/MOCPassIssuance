// using Newtonsoft.Json;

// public record Fields(
//     [property: JsonProperty(
//         "AccessToProfileByOthers",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("AccessToProfileByOthers")]
//         bool? AccessToProfileByOthers,
//     [property: JsonProperty("Balance", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Balance")]
//         int? Balance,
//     [property: JsonProperty("BundleId", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("BundleId")]
//         object BundleId,
//     [property: JsonProperty("CreationDate", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("CreationDate")]
//         DateTime? CreationDate,
//     [property: JsonProperty("Email", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Email")]
//         string Email,
//     [property: JsonProperty("EmailDisabled", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("EmailDisabled")]
//         bool? EmailDisabled,
//     [property: JsonProperty("Groups", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Groups")]
//         IReadOnlyList<string> Groups,
//     [property: JsonProperty("IsArchived", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsArchived")]
//         bool? IsArchived,
//     [property: JsonProperty("IsDonor", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsDonor")]
//         bool? IsDonor,
//     [property: JsonProperty("IsEventAttendee", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsEventAttendee")]
//         bool? IsEventAttendee,
//     [property: JsonProperty("IsMember", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsMember")]
//         bool? IsMember,
//     [property: JsonProperty("MemberId", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("MemberId")]
//         DateTime? MemberId,
//     [property: JsonProperty("MemberSince", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("MemberSince")]
//         DateTime? MemberSince,
//     [property: JsonProperty("Notes", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Notes")]
//         string Notes,
//     [property: JsonProperty("Organization", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Organization")]
//         string Organization,
//     [property: JsonProperty("Phone", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Phone")]
//         Phone Phone,
//     [property: JsonProperty("ReceiveEventReminders", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("ReceiveEventReminders")]
//         bool? ReceiveEventReminders,
//     [property: JsonProperty("ReceiveNewsletters", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("ReceiveNewsletters")]
//         DateTime? ReceiveNewsletters,
//     [property: JsonProperty("RegistredForEvent", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("RegistredForEvent")]
//         bool? RegistredForEvent,
//     [property: JsonProperty(
//         "RecievingEMailsDisabled",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("RecievingEMailsDisabled")]
//         bool? RecievingEMailsDisabled,
//     [property: JsonProperty(
//         "EmailingDisabledAutomatically",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("EmailingDisabledAutomatically")]
//         bool? EmailingDisabledAutomatically,
//     [property: JsonProperty(
//         "SystemRulesAndTermsAccepted",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("SystemRulesAndTermsAccepted")]
//         bool? SystemRulesAndTermsAccepted,
//     [property: JsonProperty("RenewalDue", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("RenewalDue")]
//         DateTime? RenewalDue,
//     [property: JsonProperty("Status", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Status")]
//         string Status,
//     [property: JsonProperty("FirstName", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("FirstName")]
//         string FirstName,
//     [property: JsonProperty("LastName", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("LastName")]
//         string LastName,
//     [property: JsonProperty("Avatar", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Avatar")]
//         string Avatar,
//     [property: JsonProperty(
//         "HasAcceptedPrivacyPolicy",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("HasAcceptedPrivacyPolicy")]
//         bool? HasAcceptedPrivacyPolicy,
//     [property: JsonProperty("DateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("DateOfBirth")]
//         DateTime? DateOfBirth,
//     [property: JsonProperty("Body Photo", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Body Photo")]
//         string BodyPhoto,
//     [property: JsonProperty("MarketPosition", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("MarketPosition")]
//         IReadOnlyList<string> MarketPosition,
//     [property: JsonProperty("HasAcceptedClubRules", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("HasAcceptedClubRules")]
//         bool? HasAcceptedClubRules,
//     [property: JsonProperty(
//         "HasAcceptedWaiverAndRelease",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("HasAcceptedWaiverAndRelease")]
//         bool? HasAcceptedWaiverAndRelease
// );

// public record FieldValue(
//     [property: JsonProperty("FieldName", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("FieldName")]
//         string FieldName,
//     [property: JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Value")]
//         object Value,
//     [property: JsonProperty("SystemCode", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("SystemCode")]
//         string SystemCode
// );

// public record MembershipLevel(
//     [property: JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Id")]
//         int? Id,
//     [property: JsonProperty("Url", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Url")]
//         string Url,
//     [property: JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Name")]
//         string Name
// );

// public record Phone(
//     [property: JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("country")]
//         string Country,
//     [property: JsonProperty("countryCallingCode", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("countryCallingCode")]
//         string CountryCallingCode,
//     [property: JsonProperty("nationalNumber", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("nationalNumber")]
//         string NationalNumber,
//     [property: JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("number")]
//         string Number
// );

// public record MOCMembershipCardRequest(
//     [property: JsonProperty("FirstName", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("FirstName")]
//         string FirstName,
//     [property: JsonProperty("LastName", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("LastName")]
//         string LastName,
//     [property: JsonProperty("Email", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Email")]
//         string Email,
//     [property: JsonProperty("DisplayName", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("DisplayName")]
//         string DisplayName,
//     [property: JsonProperty("Organization", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Organization")]
//         string Organization,
//     [property: JsonProperty("ProfileLastUpdated", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("ProfileLastUpdated")]
//         DateTime? ProfileLastUpdated,
//     [property: JsonProperty("MembershipLevel", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("MembershipLevel")]
//         MembershipLevel MembershipLevel,
//     [property: JsonProperty("MembershipEnabled", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("MembershipEnabled")]
//         bool? MembershipEnabled,
//     [property: JsonProperty("Status", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Status")]
//         string Status,
//     [property: JsonProperty("FieldValues", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("FieldValues")]
//         IReadOnlyList<FieldValue> FieldValues,
//     [property: JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Id")]
//         int? Id,
//     [property: JsonProperty("Url", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Url")]
//         string Url,
//     [property: JsonProperty("IsAccountAdministrator", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsAccountAdministrator")]
//         bool? IsAccountAdministrator,
//     [property: JsonProperty("TermsOfUseAccepted", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("TermsOfUseAccepted")]
//         bool? TermsOfUseAccepted,
//     [property: JsonProperty("Fields", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Fields")]
//         Fields Fields,
//     [property: JsonProperty(
//         "AccessToProfileByOthers",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("AccessToProfileByOthers")]
//         bool? AccessToProfileByOthers,
//     [property: JsonProperty("Balance", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Balance")]
//         int? Balance,
//     [property: JsonProperty("BundleId", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("BundleId")]
//         object BundleId,
//     [property: JsonProperty("CreationDate", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("CreationDate")]
//         DateTime? CreationDate,
//     [property: JsonProperty("EmailDisabled", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("EmailDisabled")]
//         bool? EmailDisabled,
//     [property: JsonProperty("Groups", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Groups")]
//         IReadOnlyList<string> Groups,
//     [property: JsonProperty("IsArchived", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsArchived")]
//         bool? IsArchived,
//     [property: JsonProperty("IsDonor", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsDonor")]
//         bool? IsDonor,
//     [property: JsonProperty("IsEventAttendee", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsEventAttendee")]
//         bool? IsEventAttendee,
//     [property: JsonProperty("IsMember", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("IsMember")]
//         bool? IsMember,
//     [property: JsonProperty("MemberId", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("MemberId")]
//         DateTime? MemberId,
//     [property: JsonProperty("MemberSince", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("MemberSince")]
//         DateTime? MemberSince,
//     [property: JsonProperty("Notes", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Notes")]
//         string Notes,
//     [property: JsonProperty("Phone", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Phone")]
//         Phone Phone,
//     [property: JsonProperty("ReceiveEventReminders", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("ReceiveEventReminders")]
//         bool? ReceiveEventReminders,
//     [property: JsonProperty("ReceiveNewsletters", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("ReceiveNewsletters")]
//         DateTime? ReceiveNewsletters,
//     [property: JsonProperty("RegistredForEvent", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("RegistredForEvent")]
//         bool? RegistredForEvent,
//     [property: JsonProperty(
//         "RecievingEMailsDisabled",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("RecievingEMailsDisabled")]
//         bool? RecievingEMailsDisabled,
//     [property: JsonProperty(
//         "EmailingDisabledAutomatically",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("EmailingDisabledAutomatically")]
//         bool? EmailingDisabledAutomatically,
//     [property: JsonProperty(
//         "SystemRulesAndTermsAccepted",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("SystemRulesAndTermsAccepted")]
//         bool? SystemRulesAndTermsAccepted,
//     [property: JsonProperty("RenewalDue", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("RenewalDue")]
//         DateTime? RenewalDue,
//     [property: JsonProperty("Avatar", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Avatar")]
//         string Avatar,
//     [property: JsonProperty(
//         "HasAcceptedPrivacyPolicy",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("HasAcceptedPrivacyPolicy")]
//         bool? HasAcceptedPrivacyPolicy,
//     [property: JsonProperty("DateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("DateOfBirth")]
//         DateTime? DateOfBirth,
//     [property: JsonProperty("Body Photo", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("Body Photo")]
//         string BodyPhoto,
//     [property: JsonProperty("MarketPosition", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("MarketPosition")]
//         IReadOnlyList<string> MarketPosition,
//     [property: JsonProperty("HasAcceptedClubRules", NullValueHandling = NullValueHandling.Ignore)]
//     [property: JsonPropertyName("HasAcceptedClubRules")]
//         bool? HasAcceptedClubRules,
//     [property: JsonProperty(
//         "HasAcceptedWaiverAndRelease",
//         NullValueHandling = NullValueHandling.Ignore
//     )]
//     [property: JsonPropertyName("HasAcceptedWaiverAndRelease")]
//         bool? HasAcceptedWaiverAndRelease
// );
