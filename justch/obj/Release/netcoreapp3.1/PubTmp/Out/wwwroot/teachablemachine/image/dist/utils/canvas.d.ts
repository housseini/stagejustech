/**
 * @license
 * Copyright 2019 Google LLC. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * =============================================================================
 */
declare type Drawable = HTMLImageElement | HTMLCanvasElement | HTMLVideoElement | ImageBitmap;
export declare function resize(image: Drawable, scale: number, canvas?: HTMLCanvasElement): HTMLCanvasElement;
export declare function resizeMaxTo(image: Drawable, maxSize: number, canvas?: HTMLCanvasElement): HTMLCanvasElement;
export declare function resizeMinTo(image: Drawable, minSize: number, canvas?: HTMLCanvasElement): HTMLCanvasElement;
export declare function cropTo(image: Drawable, size: number, flipped?: boolean, canvas?: HTMLCanvasElement): HTMLCanvasElement;
export {};
