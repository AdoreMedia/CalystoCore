async function SumNumbers(a, b)
{
	return a + b;
}

async function TestMe(a, b, c)
{
	let res1 = await SumNumbers(a, b);
}

async function TestMe2(a, b, c)
{
	let res1 = await SumNumbers(a, b);
	return res1;
}

async function TestMe2(a, b, c)
{
	return await SumNumbers(a, b);
}

async function* TestMe2(a, b, c)
{
	yield await SumNumbers(a, b);
}

