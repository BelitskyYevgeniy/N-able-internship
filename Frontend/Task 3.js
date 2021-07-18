const o = { a: 1, 2: 3, b: 4, 5: 6, c: 7 };
o[Symbol.iterator] = function* () {
    const keys = Object.keys(o);
    //console.log(keys);
    for (let i of keys) {
        let key = parseInt(i);
        if (!isNaN(key)) {
            yield i;
        }
    }
}
const keys = [...o]; // ['2', '5'];
console.log(keys);
