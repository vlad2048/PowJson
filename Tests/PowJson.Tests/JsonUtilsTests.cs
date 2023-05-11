using System.Text.Json;
using System.Text.Json.Serialization;
using Shouldly;
// ReSharper disable NotAccessedPositionalProperty.Local
// ReSharper disable ClassNeverInstantiated.Local

namespace PowJson.Tests;

class JsonUtilsTests
{
	[Test]
	public void ExceptionOnMissingFieldWhenDeserializing()
	{
		var recIn = new RecWithout(123);
		var str = JsonUtils.Ser(recIn);
		Should.Throw<JsonException>(() => JsonUtils.Deser<RecWith>(str));
	}

	record RecWith(
		int Num,
		[property: JsonRequired]
		string Name
	);

	record RecWithout(
		int Num
	);
}