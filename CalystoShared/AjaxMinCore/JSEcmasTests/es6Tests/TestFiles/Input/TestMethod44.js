function Skip(count) {
    return CalystoEnumerable.From(() => function* (__this)
    {
        let currindex = -1;
        for (let item of __this.AsIterableIterator())
        {
            if (++currindex < count)
                continue;
            else
                yield item;
        }
    }(this));
}