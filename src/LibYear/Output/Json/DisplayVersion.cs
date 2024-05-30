﻿using System.Text.Json.Serialization;
using LibYear.Core;

namespace LibYear.Output.Json;

internal sealed record DisplayVersion
{
	[JsonPropertyName("versionNumber")]
	public string VersionNumber { get; init; } = string.Empty;
	[JsonPropertyName("releaseDate")]
	public DateTime ReleaseDate { get; init; }
	public Release Release { get; init; }
	public DisplayVersion(Release release)
	{
		Release = release;
		VersionNumber = release.Version.ToString();
		ReleaseDate = release.Date;
	}
}