import TablesController from "./js/controller/TablesController";
import WaitersController from "./js/controller/WaitersController";

import $ from 'jquery';
import CategoriesController from "./js/controller/CategoriesController";
import CategoriesItemController from "./js/controller/CategoriesItemController";

new TablesController($('#tablesList'));
new WaitersController($('#waitersList'));
let itemsController = new CategoriesItemController($('.dish_list'));
new CategoriesController($('.dish_category'), itemsController);
