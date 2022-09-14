import TablesController from "./js/controller/TablesController";
import WaitersController from "./js/controller/WaitersController";

import $ from 'jquery';

new TablesController($('#tablesList'));
new WaitersController($('#waitersList'));