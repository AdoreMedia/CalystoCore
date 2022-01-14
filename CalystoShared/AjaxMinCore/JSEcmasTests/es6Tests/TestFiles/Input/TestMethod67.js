async function SumNumbers(a, b)
{
	return a + b;
}

async function TestMe3(a, b, c)
{
	let k1 = SumNumbers(a, b)[2]?.value(234)?.name;
	let k2 = SumNumbers(a, b)?.[2]?.value(234)?.name;
	let k3 = SumNumbers(a, b).nesto?.[2]?.value(234)?.name;
	let m1 = SumNumbers(a, b)?.value?.name;
	let k = a ?? b ?? 33;
	let g = a || b || 66;
	let m = a ? 2 : 3;
	return await Math?.max?.prop?.dva(a, b)?.name?.nesto(g, k);
}

let fun01 = (a, b) =>
{
	return SumNumbers();
}

let fun1 = async (a, b) =>
{
	return await SumNumbers();
}

let fun2 = async (a, b) =>
{
	return await SumNumbers(a);
}

let fun3 = async (a, b) =>
{
	return await SumNumbers(a, b);
}

let fun4 = async (a, b) => await SumNumbers(a, b);

