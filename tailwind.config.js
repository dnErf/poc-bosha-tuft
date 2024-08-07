/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['./Components/**/*.{html,cshtml,razor}', './node_modules/flowbite/**/*.js'],
    theme: {
        extend: {},
    },
    plugins: [require('flowbite/plugin')({ charts: false })],
}

