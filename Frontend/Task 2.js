function* flat(massive) {
    for (let i in massive) {
        if (Array.isArray(massive[i])) {
            yield* flat(massive[i]);
        }
        else
            yield massive[i];
    }
}

console.log([...flat([1, [2, [3]]])]);
