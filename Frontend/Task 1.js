 const matrix = [[1, 2, 3, 4], [5, 6, 7, 8, 9], [10, 11, 12, 13], [14, 15, 16, 17]];

function* getRows(matrix) {
    for (let row of matrix) {
        yield row;
    }
}

function transpose(matrix) {
    let copy = [];
    for (let i = 0; i < matrix.length; i++) {
        copy[i] = [];

        for (let j = 0; j < matrix[0].length; j++) {
            copy[i][j] = matrix[j][i];
        }
    }
    return copy;
}

function* getCols(matrix) {
    yield* getRows(transpose(matrix));
}
console.log([...getRows(matrix)]);
console.log([...getCols(matrix)]);
