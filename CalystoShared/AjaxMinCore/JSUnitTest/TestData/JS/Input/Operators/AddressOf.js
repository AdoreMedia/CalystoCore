function foo(x, y)
{
  return x - y;
}

var a = 10, b = 9;
foo( &a, &(b.c) );

