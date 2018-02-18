"use strict";

let path = require('path');
let webpack = require('webpack');

let entryPoint = './src/main.js';
let outputPath = path.resolve(__dirname, './dist');
let fileName = 'build.js';

let plugins = [];
module.exports = {
	entry: {
		app: [ entryPoint ]
	},
	output: {
		path: outputPath,
		filename: fileName
	},
	module: {
		rules: [
			{
				test: /\.js$/,
				exclude: /(node_modules|bower_components)/,
				loader: 'babel-loader',
				query: {
					presets: ['es2015']
				}
			},
			{
				test: /\.vue$/,
				loader: 'vue-loader'
			}
		]
	},
	resolve: {
		alias: {
			'vue$': 'vue/dist/vue.esm.js'
		}
	},
	plugins
};